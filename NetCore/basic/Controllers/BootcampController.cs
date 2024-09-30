using basic.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic.Controllers
{
    public class BootcampController : Controller
    {
        // bootcamp/index
        public IActionResult Index()
        {
            var kurs = new Bootcamp();
            kurs.BootcampId = 1;
            kurs.Title = "AspNetCore MVC Bootcamp";
            kurs.Description = "Bu bootcamp 1 ay sürecek mvc derslerini öğreneceksiniz.";
            kurs.Image = "1.jpg";
            return View(kurs);
        }
        //bootcamp/list
        public IActionResult List()
        {
            return View(Repository.Bootcamps);
        }
        //bootcamp/details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List", "Bootcamp");
            }
            var bootcamp = Repository.GetById(id);
            return View(bootcamp);
        }
    }
}