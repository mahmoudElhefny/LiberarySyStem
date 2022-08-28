using Library.Models;
using Library.Repositories;
using Library.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IWishListRepository wishListRepository;
        private readonly Context context;

        public BookController(IBookRepository bookRepository,IWishListRepository wishListRepository,Context context)
        {
            this.bookRepository = bookRepository;
            this.wishListRepository = wishListRepository;
            this.context = context;
        }
        public IActionResult TellMessage(TellMessage errorModel)
        {
            return View("TellMessage", errorModel);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            var categories = context.Categories.ToList();
            var authors = context.Authors.ToList();
            var publishers = context.Publishers.ToList();
            var extraModelData = new AuthorCategoryPublisherVM()
            {
                authors = authors,
                publishers = publishers,
                categories = categories
            };
            ViewData["Extra"] = extraModelData;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(BookVM bookVM)
        {
            if (ModelState.IsValid && bookVM.CategoryId != -1 && bookVM.AuthorId != -1 && bookVM.PublisherId != -1)
            {
                try
                {
                    bool addResult = bookRepository.Add(bookVM);
                    if (addResult == false)
                    {
                        return View(bookVM);
                    }
                }
                catch (Exception ex)
                {
                    TellMessage tellMessage = new TellMessage() { 
                    Header="Error",
                    Action="Add",
                    Controller = "Book",
                    Message=ex.Message.ToString(),
                    ButtonLabel="Back To Add Book Page"
                    };
                    return View("TellMessage", tellMessage);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(bookVM);
        }
        [HttpGet]
        public IActionResult addBook(BookVM bookVM)
        {
            bookRepository.addBook(bookVM);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                BookVM model = bookRepository.GetUpdate(id);
                var categories = context.Categories.ToList();
                var authors = context.Authors.ToList();
                var publishers = context.Publishers.ToList();
                var extraModelData = new AuthorCategoryPublisherVM()
                {
                    authors = authors,
                    publishers = publishers,
                    categories = categories
                };
                ViewData["Extra2"] = extraModelData;
                return View(model);
            }catch(Exception ex)
            {
                TellMessage tellMessage = new TellMessage() { 
                Header="Error",
                Action = "Index",
                Controller = "Home",
                Message = $"Error Message Say : \n{ex.Message}",
                ButtonLabel = "Go Home"
                };
                return View("TellMessage", tellMessage);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id,BookVM model)
        {
            if (ModelState.IsValid && model.CategoryId!=-1 && model.AuthorId!=-1 && model.PublisherId!=-1)
            {
                try
                {
                    bookRepository.SaveUpdate(id, model);
                    //var allBooks = bookRepository.ShowAll();
                }
                catch
                {
                    TellMessage tellMessage = new TellMessage()
                    {
                        Header = "Info",
                        Action = "Index",
                        Controller = "Home",
                        Message = $"Error Message Say : Updating ... ",
                        ButtonLabel = "Go Home"
                    };
                    return View("TellMessage", tellMessage);
                }
                TellMessage message = new TellMessage();
                message.Header = "Success";
                message.Action = "ShowAll";
                message.Controller = "Book";
                message.Message = "Book Updated Successfully";
                message.ButtonLabel = "Back To Book List";
                return View("TellMessage", message);
                //return RedirectToAction("ShowAll");
            }
            return View(model);
        }
        public IActionResult ShowAll()
        {
            try
            {
                var books = bookRepository.ShowAll();
                return View(books);
            }catch (Exception ex)
            {
                TellMessage tellMessage = new TellMessage()
                {
                    Header = "Warning",
                    Action = "Add",
                    Controller = "Book",
                    Message = $"Warning Message Say : \n{ex.Message}",
                    ButtonLabel = "Go To Add Books"
                };
                return RedirectToAction("TellMessage", tellMessage);
            }
        }
        public IActionResult Delete(int id)
        {
            bool deleteResult = false;
            TellMessage message = new TellMessage();
            try
            {
                deleteResult = bookRepository.deleteBook(id);
                if (deleteResult)
                {
                    message.Header = "Success";
                    message.Action = "ShowAll";
                    message.Controller = "Book";
                    message.ButtonLabel = "Back To All Books";
                    message.Message = "Book Deleted Successfully .";
                }
                else
                {
                    message.Header = "Error";
                    message.Action = "ShowAll";
                    message.Controller = "Book";
                    message.ButtonLabel = "Back To All Books";
                    message.Message = "Can not Delete Book !";
                }                
            }
            catch(Exception ex)
            {
                message.Header = "Error";
                message.Action = "ShowAll";
                message.Controller = "Book";
                message.ButtonLabel = "Back To All Books";
                message.Message = $"Message Says : {ex.Message}";
            }
            return View("TellMessage", message);
        }

        public IActionResult GetById(int id)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                    bool IsInWishList = wishListRepository.IsBookInWishListOfCurrentUser(userId, id);
                    ViewData["IsInWishListResult"] = IsInWishList;
                }
                var book = bookRepository.GetBookById(id);
                return View("Details",book);

            }catch(Exception ex)
            {
                TellMessage message = new TellMessage();
                message.Header = "Error";
                message.Action = "Index";
                message.Controller = "Home";
                message.ButtonLabel = "Back To All Books";
                message.Message = $"Message Says : {ex.Message}";
                return View("TellMessage",message);
            }
        }
    }
}
