using EfCoreApp.DataEntity;
using EfCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Controllers
{
    public class BootcampController : Controller
    {
        private readonly DataContext _context;

        public BootcampController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var bootcamp = _context.Bootcamps.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.SearchString = searchString.ToLower();
                bootcamp = bootcamp.Where(o => o.BootcampName!.ToLower().Contains(searchString));
            }

            return View(await bootcamp.Include(x => x.Egitmen).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Egitmenler = new SelectList(await _context.Egitmenler.ToListAsync(), "EgitmenId", "AdSoyad");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BootcampViewModel model, IFormFile imageFile)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var extensions = Path.GetExtension(imageFile.FileName);
            var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extensions}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

            if (imageFile != null)
            {
                if (!allowedExtensions.Contains(extensions))
                {
                    ModelState.AddModelError("", "Lütfen geçerli bir format giriniz!");
                }
            }
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                }

                model.Image = randomFileName;

                var selectedEgitmen = await _context.Egitmenler.FindAsync(model.EgitmenId);

                var newBootcamp = new Bootcamp()
                {
                    BootcampName = model.BootcampName,
                    Image = model.Image,
                    EgitmenId = model.EgitmenId
                };

                _context.Bootcamps.Add(newBootcamp);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Bootcamp");
            }
            ViewBag.Egitmenler = new SelectList(await _context.Egitmenler.ToListAsync(), "EgitmenId", "AdSoyad");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bootcamp = await _context.Bootcamps.Include(b => b.BootcampKayits).ThenInclude(b => b.Ogrenci).FirstOrDefaultAsync(b => b.BootcampId == id);
            if (bootcamp == null)
            {
                return NotFound();
            }
            return View(bootcamp);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bootcamp = await _context.Bootcamps.FindAsync(id);
            if (bootcamp == null)
            {
                return NotFound();
            }
            return View(bootcamp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Bootcamp model, IFormFile? imageFile)
        {
            if (id != model.BootcampId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                    var extensions = Path.GetExtension(imageFile.FileName);
                    var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extensions}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");

                    if (path != null)
                    {
                        var fullPath = Path.Combine(path, randomFileName);
                        if (fullPath != null)
                        {
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                await imageFile.CopyToAsync(stream);
                            }
                            model.Image = randomFileName;
                        }
                    }
                }
                else
                {
                    var existingImage = _context.Bootcamps.Where(o => o.BootcampId == id).Select(o => o.Image).FirstOrDefault();
                    model.Image = existingImage;
                }
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var bootcamp = await _context.Bootcamps.FindAsync(id);
            if (bootcamp == null)
            {
                return NotFound();
            }
            _context.Bootcamps.Remove(bootcamp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}