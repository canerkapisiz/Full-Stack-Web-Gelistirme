using EfCoreApp.DataEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Controllers
{
    public class BootcampKayitController : Controller
    {
        private readonly DataContext _context;

        public BootcampKayitController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var BootcampKayitlari = await _context.Kayitlar.Include(x => x.Ogrenci).Include(x => x.Bootcamp).ToListAsync();
            return View(BootcampKayitlari);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciId", "AdSoyad");
            ViewBag.Bootcamps = new SelectList(await _context.Bootcamps.ToListAsync(), "BootcampId", "BootcampName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BootcampKayit model)
        {
            model.KayitTarihi = DateTime.Now;
            _context.Kayitlar.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}