using Library.Models;
using Library.Repositories.Authors;
using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository author;

        public AuthorController(IAuthorRepository _author)
        {
            author = _author;
        }
        public IActionResult Index()
        {
            return View("AllAuthors", author.GetAuthors());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Add(AuthorVM model)
        {
            Author auth = new Author();
            if (ModelState.IsValid)
            {
                auth.Name = model.Name;
                auth.BirthYear = model.BirthYear;
                
                author.AddAuthor(auth);
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Edit(int id)
        {
            return View("Edit",author.findById(id));
        }
        [HttpPost]
        public IActionResult Edit(int id, AuthorVM authorVM)
        {
            Author auth = new Author();
            if (ModelState.IsValid)
            {
                auth.Name = authorVM.Name;
                auth.BirthYear = authorVM.BirthYear;
                author.Edit(id, auth);
                return RedirectToAction("Index");
            }
            return View("Edit", author.findById(id));
        }
        public IActionResult Delete(int id)
        {
            author.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
