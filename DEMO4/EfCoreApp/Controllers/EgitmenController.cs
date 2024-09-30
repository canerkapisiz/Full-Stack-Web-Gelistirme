using EfCoreApp.DataEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Controllers
{
    public class EgitmenController : Controller
    {
        private readonly DataContext _context;

        public EgitmenController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var Egitmenler = _context.Egitmenler.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.SearchString = searchString.ToLower();
                Egitmenler = Egitmenler.Where(o => o.EgitmenAd!.ToLower().Contains(searchString));
            }

            return View(await Egitmenler.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Egitmen model, IFormFile imageFile)
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
                _context.Egitmenler.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogr = await _context.Egitmenler.Include(x => x.Bootcamps).FirstOrDefaultAsync(o => o.EgitmenId == id);
            if (ogr == null)
            {
                return NotFound();
            }
            return View(ogr);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogr = await _context.Egitmenler.FindAsync(id);
            if (ogr == null)
            {
                return NotFound();
            }
            return View(ogr);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Egitmen model, IFormFile? imageFile)
        {
            if (id != model.EgitmenId)
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
                    var existingImage = _context.Egitmenler.Where(o => o.EgitmenId == id).Select(o => o.Image).FirstOrDefault();
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
            var ogr = await _context.Egitmenler.FindAsync(id);
            if (ogr == null)
            {
                return NotFound();
            }
            _context.Egitmenler.Remove(ogr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}