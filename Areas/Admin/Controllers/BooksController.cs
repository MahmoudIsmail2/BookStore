using BookStore.Areas.Admin.Models;
using BookStore.Bl;
using BookStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BooksController : Controller
    {
        ApplicationDbContext context;
        IClsBooks clsbooks;
        IClsAuthors clsAuthors;
        IClsCategories clsCategories;
        public BooksController(ApplicationDbContext _context,IClsBooks _clsbooks,IClsAuthors _clsAuthors,IClsCategories _clsCategories)
        {
            context= _context;  
            clsbooks= _clsbooks;
            clsAuthors= _clsAuthors;
            clsCategories= _clsCategories;  
           
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.Authors =clsAuthors.GetAll().Where(a=>!a.IsDeleted);
            ViewBag.Categories =clsCategories.GetAll().Where(a => !a.IsDeleted);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(List<IFormFile>img,TbBooks book )
        {
            if (book.BookId == 0)
            {
                var imgname = UploadImage(img);
                book.ImageUrl = imgname.Result;
            }

            if (ModelState.IsValid)
            {
                var result= clsbooks.Save(book);
                if (result)
                    return RedirectToAction(nameof(List));
                else
                    return RedirectToAction(nameof(Create));
            }
            return View(nameof(List));
        }
        public IActionResult Edit(int id)
        {       
            var book=clsbooks.GetById(id);
            ViewBag.Authors = clsAuthors.GetAll().Where(a => !a.IsDeleted).ToList();
            ViewBag.Categories = clsCategories.GetAll().Where(a => !a.IsDeleted).ToList();
            return View(book);
        }
        async Task<string> UploadImage(List<IFormFile> Files)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Admin\Uploads/Books", ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                        return ImageName;
                    }
                }
            }
            return string.Empty;
        }

    }
}
