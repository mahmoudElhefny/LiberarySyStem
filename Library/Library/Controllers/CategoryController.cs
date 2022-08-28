using Library.Models;
using Library.Repositories.CategoryRepository;
using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository category;

        public CategoryController(ICategoryRepository _category)
        {
            category = _category;
        }
        public IActionResult Index()
        {
            return View("AllCategories", category.GetCategories()); 
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("AddCategory");
        }
      [HttpPost]
      
        public IActionResult Add(CategroyVM model)
        {
            Category cat = new Category();
            if (ModelState.IsValid)
            {
                cat.Name=model.Name;
                category.AddCategory(cat);
                return RedirectToAction("Index");
            }
            return View("AddCategory");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            
            return View("Edit", category.findById(id));
        }
        [HttpPost]
        public IActionResult Edit(int id,CategroyVM categroyVM)
        {
            Category cate = new Category();
            if (ModelState.IsValid)
            {
                cate.Name = categroyVM.Name;
                category.Edit(id, cate);
                return RedirectToAction("Index");
            }
              return View("Edit", category.findById(id));
        }
        public IActionResult Delete(int id)
        {
            category.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
