using Library.Models;
using Library.Repositories;
using Library.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BorrowController : Controller
    {
        private readonly Context context;
        private readonly IBookRepository bookRepository;

        public BorrowController(Context context,IBookRepository bookRepository )
        {
            this.context = context;
            this.bookRepository = bookRepository;
        }
        public bool CheckMaxDaysToHireBook(DateTime hire,DateTime retrieve)
        {
            int NumOfDays = retrieve.Subtract(hire).Days;
            bool validateResult = false;
            if(NumOfDays > 0 && NumOfDays <= 30)
            {
                validateResult = true;
            }
            return validateResult;
        }
        public IActionResult Index()
        {
            var borrowList = context.borrowBooks.OrderBy(x=>x.IsRetrived).ToList();
            if(borrowList.Count > 0)
            {
                return View(borrowList);
            }
            else
            {
                var message = "There Was No Vistors Borrowed Any Books";
                ViewData["Message"] = message;
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult Deliver(string UserName,string BookTitle)
        {
            var borrow = context.borrowBooks.OrderBy(x=>x.IsRetrived).FirstOrDefault(x => x.BookTitle == BookTitle && x.UserName == UserName);
            if(borrow != null)
            {
                borrow.IsRetrived = true;
                //increase copy by 1
                var bookTarget = context.Books.Where(x => x.Title == BookTitle).FirstOrDefault();
                if (bookTarget != null)
                {
                    bookTarget.Copies += 1;
                }
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult MakeBorrow()
        {
            try
            {
                var users = context.Users.ToList();
                var books = bookRepository.ShowAll();
                ViewData["Users"] = users;
                return View(books);
            }
            catch
            {
                TellMessage message = new TellMessage()
                {
                    Header = "Warning",
                    Action = "Index",
                    Controller = "Home",
                    Message = "No Books Or No Users Or Both !",
                    ButtonLabel = "Ok"
                };
                return View("TellMessage", message);
            }
            
        }
        [HttpPost]
        public IActionResult MakeBorrowOperation(BorrowVM model)
        {
            if (ModelState.IsValid)
            {
                var haveBook = context.borrowBooks.Where(x => x.UserName == model.UserName && x.IsRetrived == false).FirstOrDefault();
                if(haveBook != null)
                {
                    TellMessage message = new TellMessage();
                    message.Action = "Index";
                    message.Controller = "Borrow";
                    message.Message = "User Already Have A Book !";
                    message.ButtonLabel = "View Borrow List";
                    message.Header = "Warning";
                    return View("TellMessage", message);
                    //return RedirectToAction("MakeBorrow");
                }
                var ISBookavailable = context.Books.Where(x => x.Title == model.BookTitle && x.IsAvalable == true && x.Copies > 0).FirstOrDefault();
                if(ISBookavailable == null)
                {
                    TellMessage message1 = new TellMessage();
                    message1.Action = "MakeBorrow";
                    message1.Controller = "Borrow";
                    message1.Message = "Book is Not Available Now, Borrow Anthor Book !";
                    message1.ButtonLabel = "OK";
                    message1.Header = "Warning";
                    return View("TellMessage", message1);
                }
                BorrowBooks borrowBooks = new BorrowBooks()
                {
                    BookTitle = model.BookTitle,
                    UserName = model.UserName,
                    HireDate = model.HireDate,
                    RetrieveDate = model.RetrieveDate,
                    IsRetrived = false,
                };
                //decrement copy
                var bookTarget = context.Books.Where(x => x.Title == model.BookTitle).FirstOrDefault();
                if(bookTarget != null)
                {
                    bookTarget.Copies -= 1;
                }
                //do operation
                context.borrowBooks.Add(borrowBooks);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TellMessage msg = new TellMessage();
                msg.Action = "MakeBorrow";
                msg.Controller = "Borrow";
                msg.Message = "Borrow Date Must Be Before Retrive Date !\t\nPeriod Time Must Less The One Month !\t\nSpecify Borrow Date And Retrieve Date!";
                msg.ButtonLabel = "Back To Make Borroing Operation !";
                msg.Header = "Warning";
                return View("TellMessage", msg);

            }
        }

        [HttpGet]
        public IActionResult UserHistory()
        {
            var users = context.Users.ToList();
            if(users.Count > 0)
            {
                ViewData["users"] = users;
                return View();
            }
            else
            {
                TellMessage message = new TellMessage();
                message.Action = "Index";
                message.Controller = "Borrow";
                message.Message = "No Users !";
                message.ButtonLabel = "Back";
                message.Header = "Warning";
                return View("TellMessage", message);
            }
        }
        [HttpPost]
        public IActionResult UserHistory(string UserName)
        {
            var borrowResult = context.borrowBooks.OrderBy(x => x.IsRetrived).Where(x=>x.UserName==UserName).ToList();
            if (borrowResult != null)
            {
                return View("Index",borrowResult);
            }
            else
            {
                TellMessage message = new TellMessage();
                message.Action = "Index";
                message.Controller = "Borrow";
                message.Message = $"No Borrow History For User : {UserName} !";
                message.ButtonLabel = "Back";
                message.Header = "Info";
                return View("TellMessage", message);
            }
        }

    }
}
