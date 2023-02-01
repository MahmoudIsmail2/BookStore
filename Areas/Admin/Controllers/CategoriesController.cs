using BookStore.Bl;
using BookStore.Data;
using BookStore.Domains;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        IClsCategories clscategories;
        ApplicationDbContext context;
        public CategoriesController(IClsCategories _clscategories,ApplicationDbContext _context)
        {
            clscategories = _clscategories;
            context = _context;
        }
        public IActionResult List(string message) {          
            ViewBag.Save = message;         
            var lstcategories = clscategories.GetAll();
            return View(lstcategories);
        }
        public IActionResult Create()
        {          
            return View();
        }
        public IActionResult Edit(int id)
        {
            var category =clscategories.GetById(id);
            return View("Edit",category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbCategories model )
        {
            if (ModelState.IsValid)
            {
                clscategories.Save(model);
                if (model.CategoryId == 0)
                    return RedirectToAction("List", new { message = "Done" });
                else

                    return RedirectToAction("List", new { message = "Updated" });

            }
            else
            {
                return RedirectToAction("Create", model);
            }

           
        }
        [HttpPost]
        public IActionResult Delete(int categoryid)
        {
            if (clscategories.Delete(categoryid))
                return RedirectToAction(nameof(List));
            else
                return NotFound();
        }
        public IActionResult AllowCategory(TbCategories category)
       {
            try
            {
                var isexists=context.TbCategories.Any(c => c.CategoryName==category.CategoryName);
                return Json ( !isexists);  
            }
            catch(Exception ex)
            {
                return Json(false);
            }
           
        }


    }
}
