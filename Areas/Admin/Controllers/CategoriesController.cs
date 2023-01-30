using BookStore.Bl;
using BookStore.Domains;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        IClsCategories clscategories;
        public CategoriesController(IClsCategories _clscategories)
        {
            clscategories = _clscategories;
        }
        public IActionResult List(string message)
        {
            ViewBag.Save=message;
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
            if(ModelState.IsValid)
            {
                clscategories.Save(model);           
                return RedirectToAction("List", new { message = model.CategoryId == 0 ? "Done" : "Updated" });
            }
            else
            {
                return RedirectToAction("Create",model);
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

    }
}
