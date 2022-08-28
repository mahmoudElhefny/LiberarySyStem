using Library.Models;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWishListRepository wishListRepository;
        private readonly IBookRepository bookRepository;

        public HomeController(ILogger<HomeController> logger,IWishListRepository wishListRepository, IBookRepository bookRepository)
        {
            _logger = logger;
            this.wishListRepository = wishListRepository;
            this.bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                    var list = wishListRepository.GetAll(userId);
                    ViewData["WishList"] = list;
                }
                var books = bookRepository.ShowAll();
                return View(books);
            }
            catch(Exception ex)
            {
                TellMessage message = new TellMessage()
                {
                    Action = "Index",//go to contact section when develop it
                    Controller = "Home",
                    Header = "Warning",
                    Message = $"Message Says : {ex.Message}",
                    ButtonLabel = "OK"
                };
                return View("TellMessage", message);
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}