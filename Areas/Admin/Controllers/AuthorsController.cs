using BookStore.Bl;
using BookStore.Data;
using BookStore.Domains;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorsController : Controller
    {
        IClsAuthors clsAuthors;
        ApplicationDbContext context;
        public AuthorsController(IClsAuthors _clsAuthors, ApplicationDbContext _context)
        {
            clsAuthors = _clsAuthors;
            context = _context;
        }
        public IActionResult List(string message)
        {
            ViewBag.Save = message;
            var lstAuthors = clsAuthors.GetAll();
            return View(lstAuthors);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var Author = clsAuthors.GetById(id);
            return View("Edit", Author);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbAuthors model)
        {
            if (ModelState.IsValid)
            {
                if(model.AuthorId==0)
                {
                    clsAuthors.Save(model);
                    return RedirectToAction("List", new { message = "Done" });
                }
                
                else
                    clsAuthors.Save(model);
                   return RedirectToAction("List", new { message = "Updated" });

            }
            else
            {
                return RedirectToAction("Create", model);
            }


        }
        [HttpPost]
        public IActionResult Delete(int Authorid)
        {
            if (clsAuthors.Delete(Authorid))
                return RedirectToAction(nameof(List));
            else
                return NotFound();
        }
        public IActionResult AllowAuthor(TbAuthors Author)
        {
            try
            {
                var isexists = context.TbAuthors.Any(c => c.AuthorName == Author.AuthorName);
                return Json(!isexists);
            }
            catch (Exception ex)
            {
                return Json(false);
            }

        }


    }
}
