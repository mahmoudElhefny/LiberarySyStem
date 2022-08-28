using Library.Models;
using Library.Repositories;
using Library.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly ISearchRepository searchRepository;
        private readonly IWishListRepository wishListRepository;

        public SearchController(ICategoryRepository categoryRepository,IAuthorRepository authorRepository,ISearchRepository searchRepository,IWishListRepository wishListRepository)
        {
            this.categoryRepository = categoryRepository;
            this.authorRepository = authorRepository;
            this.searchRepository = searchRepository;
            this.wishListRepository = wishListRepository;
        }
        public IActionResult Index()
        {
            var authors = authorRepository.GetAuthors();
            var categories = categoryRepository.GetCategories();
            ViewData["categories"] = categories;
            return View(authors);
        }
        [HttpPost]
        public IActionResult SearchByTitleOrISBN(SearchForBookVM model)
        {
            if (ModelState.IsValid)
            {
                Book book = searchRepository.FindBookByNameOrByISBN(model.SearchText);
                if (book != null)
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                        bool IsInWishList = wishListRepository.IsBookInWishListOfCurrentUser(userId, book.Id);
                        ViewData["IsInWishListResult"] = IsInWishList;
                    }
                    return View("BookDetails", book);
                }
                else
                {

                    string Error = $"No Book Found With ISBN \"{model.SearchText}\" or Book Title \"{model.SearchText}\" Found";
                    ViewData["ErrorMSG"] = Error;
                    TellMessage message1 = new TellMessage()
                    {
                        Header = "Warning",
                        Action = "Index",
                        Controller = "Search",
                        ButtonLabel = "Back To Search",
                        Message = Error
                    };
                    return View("TellMessage", message1);
                    //return RedirectToAction("Index");
                }
            }
            TellMessage message = new TellMessage()
            {
                Header = "Warning",
                Action = "Index",
                Controller = "Search",
                ButtonLabel = "Back To Search",
                Message = "You Have To Write Search Keyword !"
            };
            return View("TellMessage", message);
        }

        [HttpPost]
        public IActionResult SearchByCategory(int id)
        {
            List<Book> books = searchRepository.SearchByCategory(id);
            if (books!=null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                    var wishList = wishListRepository.GetAll(userId);
                    ViewData["WishList"] = wishList;
                }
                    return View("FilterBooks", books);
            }
            else
            {
                TellMessage message1 = new TellMessage()
                {
                    Header = "Warning",
                    Action = "Index",
                    Controller = "Search",
                    ButtonLabel = "Back To Search",
                    Message = "No Book Found With Selected Category !"
                };
                return View("TellMessage", message1);
            }


        }

        [HttpPost]
        public IActionResult SearchByAuthor(int id)
        {
            List<Book> books = searchRepository.SearchByAuthor(id);
            if (books != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                    var wishList = wishListRepository.GetAll(userId);
                    ViewData["WishList"] = wishList;
                }
                return View("FilterBooks", books);
            }
            else
            {
                TellMessage message1 = new TellMessage()
                {
                    Header = "Warning",
                    Action = "Index",
                    Controller = "Search",
                    ButtonLabel = "Back To Search",
                    Message = "No Book Found With Selected Author !"
                };
                return View("TellMessage", message1);
            }


        }

    }
}
