using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View("MainPage");
        }
    }
}
