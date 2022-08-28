using Library.Models;
using Library.Repositories;
using Library.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    public class WishListController : Controller
    {
        private readonly IWishListRepository wishLisRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public WishListController(
            IWishListRepository wishLisRepository,
            UserManager<ApplicationUser> userManager
            )
        {
            this.wishLisRepository = wishLisRepository;
            this.userManager = userManager;
        }
        public IActionResult TellMessage(TellMessage errorModel)
        {
            return View("TellMessage", errorModel);
        }
        //[HttpGet]
        //public IActionResult add()
        //{
        //    return View("AddToWishList");  
        //}
        [HttpPost]
        [HttpGet]
        
        public IActionResult Add(WishList model)
        {
            TellMessage errorModel = new TellMessage()
            {
                Action = "Index",
                Controller = "Home",
                ButtonLabel = "Back To Home Page",
                Message = "Unable To Add Book To WishList",
                Header = "Error"
            };
            if (ModelState.IsValid) 
            {
                
                bool addResult = false;
                try
                {
                    addResult = wishLisRepository.Add(model);
                }
                catch (Exception e)
                {
                    errorModel.Message = e.Message.ToString();
                }
                if (addResult)
                {
                    return RedirectToAction("Show");
                }
            }
           // return View("AddToWishList", model);
            return RedirectToAction("TellMessage", errorModel);
        }
        [HttpGet]
        public JsonResult WishListCount()
        {
            Context context = new Context();
            IWishListRepository wishListRepository = new WishListRepository(context);
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var BookListCount = wishListRepository.GetAll(UserId).ToList().Count();
            WishListCountVM model = new WishListCountVM();
            model.Count = BookListCount;
            return Json(model);
        }
        

        //[HttpGet]
        //public IActionResult Show()
        //{
        //    return View();
        //}
        [HttpGet]
        public async Task<IActionResult> Show(string UserId)
        {
            
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var BookList = wishLisRepository.GetAll(UserId);
            if (BookList.Count > 0)
            {
                List<Book> books = new List<Book>();
                books = BookList;
                return View(books);
            }
            TellMessage tellMessage = new TellMessage() {
                Header = "Warning",
                Controller = "Home",
                Action = "Index",
                ButtonLabel = "Go To Home",
                Message = $"No Books Added To WishList !"
            };
            return View("TellMessage",tellMessage);
        }
        [HttpGet]
        public IActionResult RemoveFromWishList(int id)
        {
            bool removeState = wishLisRepository.remove(id);
            if (removeState)
            {
                return RedirectToAction("Show");
            }
            TellMessage errorModel = new TellMessage()
            {
                Action = "Show",
                Controller = "WishList",
                ButtonLabel = "Back To WishList",
                Message = "Unable To Remove Book From WishList",
                Header = "Error"
            };
            return View("TellMessage",errorModel);
        }
    }
}
