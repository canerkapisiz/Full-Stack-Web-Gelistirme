using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;

namespace BookApp.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {

    }

    public IActionResult Index(string searchString, string category)
    {
        var books = Repository.Products;
        if (!String.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString;
            books = books.Where(b => b.BookName!.ToLower().Contains(searchString)).ToList();
        }
        if (!String.IsNullOrEmpty(category))
        {
            books = books.Where(b => b.CategoryId == int.Parse(category)).ToList();
        }

        var model = new ProductViewModel
        {
            Products = books,
            Categories = Repository.Categories,
            SelectedCategory = category
        };
        return View(model);
    }

    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var entity = Repository.Products.FirstOrDefault(b => b.BookId == id);
        if (entity == null)
        {
            return NotFound();
        }
        return View(entity);
    }

    [HttpGet]
    public IActionResult Admin()
    {
        return View(Repository.Products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductBook model, IFormFile imageFile)
    {
        var aloowedExtensions = new[] { ".jpg", ".jepg", ".png" };
        var extensions = Path.GetExtension(imageFile.FileName);
        var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extensions}");
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

        if (imageFile != null)
        {
            if (!aloowedExtensions.Contains(extensions))
            {
                ModelState.AddModelError("", "Lütfen geçerli bir resim seçiniz.");
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
            model.BookId = Repository.Products.Count + 1;
            Repository.CreateBook(model);
            return RedirectToAction("Admin");
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var entity = Repository.Products.FirstOrDefault(b => b.BookId == id);
        if (entity == null)
        {
            return NotFound();
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, ProductBook model, IFormFile? imageFile)
    {
        if (id != model.BookId)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            if (imageFile != null)
            {
                var aloowedExtensions = new[] { ".jpg", ".jepg", ".png" };
                var extensions = Path.GetExtension(imageFile.FileName);
                var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extensions}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                if (imageFile != null)
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    model.Image = randomFileName;
                }
                Repository.EditBook(model);
                return RedirectToAction("Admin");
            }
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var entity = Repository.Products.FirstOrDefault(b => b.BookId == id);
        if (entity == null)
        {
            return NotFound();
        }
        return View(entity);
    }

    [HttpPost]
    public IActionResult Delete(int id, int BookId)
    {
        if (id != BookId)
        {
            return NotFound();
        }
        var entity = Repository.Products.FirstOrDefault(b => b.BookId == BookId);
        if (entity == null)
        {
            return NotFound();
        }
        Repository.DeleteBook(entity);
        return RedirectToAction("Admin");
    }
}
