using Library.Models;
using Library.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Context context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public BookRepository(Context context ,IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        private string UploadedFile(BookVM model)
        {
            string uniqueFileName = null;

            if (model.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images/Book");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.ImageFile.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            //upload image and return image name which must be stored in DB
            return uniqueFileName;
        }
        private void DeleteImage(string path)
        {
            string fullPath = Path.Combine(webHostEnvironment.WebRootPath, path);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }
        public bool Add(BookVM bookVM)
        {
            string imageName = "";
            try
            {
               imageName = UploadedFile(bookVM);
            }catch(Exception ex)
            {
                return false;
            }
            Book book = new Book();
            book.ISBN = bookVM.ISBN;
            book.IsAvalable = bookVM.IsAvalable;
            book.Title = bookVM.Title;
            book.Version=bookVM.Version;
            book.Description = bookVM.Description;
            book.CoverImage = imageName;
            book.Copies = bookVM.Copies;
            book.PagesCount = bookVM.PagesCount;
            book.PublishedYear = bookVM.PublishedYear;
            book.PublisherId = bookVM.PublisherId;
            book.AuthorId = bookVM.AuthorId;
            book.CategoryId = bookVM.CategoryId;
            context.Books.Add(book);
            context.SaveChanges();  
            return true;
        }
        public void addBook(BookVM bookVM)
        {
            Book book = new Book();
            book.ISBN = 87363;
            book.Version = "1.2.0";
            book.IsAvalable = true;
            book.Title = "spider";
            book.Description = "this is a description";
            book.CoverImage = "01.jpg";
            book.Copies = 30;
            book.PagesCount = 309;
            book.PublishedYear = 2001;
            book.PublisherId = 1;
            book.AuthorId = 3;
            book.CategoryId = 2;
            context.Books.Add(book);
            context.SaveChanges();
        }
        public BookVM GetUpdate(int id)
        {
            Book TargetBook = context.Books.FirstOrDefault(x=>x.Id == id);
            if (TargetBook != null)
            {
                BookVM bookVM = new BookVM();
                bookVM.Title = TargetBook.Title;
                bookVM.ISBN = TargetBook.ISBN;
                bookVM.Copies = TargetBook.Copies;
                bookVM.Description = TargetBook.Description;
                bookVM.Version = TargetBook.Version;
                bookVM.PublishedYear = TargetBook.PublishedYear;
                bookVM.AuthorId = TargetBook.AuthorId;
                bookVM.PublisherId = TargetBook.PublisherId;
                bookVM.CategoryId = TargetBook.CategoryId;
                bookVM.PagesCount = TargetBook.PagesCount;
                bookVM.IsAvalable = TargetBook.IsAvalable;
                return bookVM;
            }
            throw new NullReferenceException($"Book Can not get Book With Id = {id}");
        }
        public void SaveUpdate(int id, BookVM bookVM)
        {
            Book OldBook = context.Books.FirstOrDefault(x => x.Id == id);
            if (OldBook != null)
            {
                try
                {
                    DeleteImage($"/Images/Book/{OldBook.CoverImage}");
                }
                catch
                {

                }
                string ImageName="";
                try
                {
                    ImageName = UploadedFile(bookVM);
                }
                catch
                {
                    ImageName = "without Cover Iamge !";
                }
                
                OldBook.CoverImage = ImageName;
                OldBook.Title= bookVM.Title;   
                OldBook.ISBN= bookVM.ISBN ;  
                OldBook.Copies= bookVM.Copies;  
                OldBook.Description= bookVM.Description ;  
                OldBook.Version = bookVM.Version ;  
                OldBook.PublishedYear = bookVM.PublishedYear ; 
                OldBook.AuthorId= bookVM.AuthorId ;    
                OldBook.PublisherId = bookVM.PublisherId;    
                OldBook.CategoryId = bookVM.CategoryId;      
                OldBook.PagesCount = bookVM.PagesCount;
                OldBook.IsAvalable = bookVM.IsAvalable;
                context.SaveChanges();
            }
            //throw new NullReferenceException($"Can not get Book With Id = {id}");
        }
        public List<Book> ShowAll()
        {
            var books = context.Books.Include(x=>x.author).Include(x=>x.Category).Include(x=>x.Publisher).ToList();
            if(books.Count > 0)
            {
                return books;
            }
            throw new NullReferenceException("No Books Exists To Display in Library, Ask WebSite \" In Contact Section \" to Add Books .");
        }
        public bool deleteBook(int id)
        {
            var TargetBook = context.Books.FirstOrDefault(x => x.Id==id);
            bool deleteResult = false;
            if(TargetBook != null)
            {
                context.Books.Remove(TargetBook);
                context.SaveChanges();
                deleteResult = true;
            }
            try
            {
                DeleteImage($"/Images/Book/{TargetBook.CoverImage}");
            }catch
            {
                throw new Exception("Can Not Delete Or Find Image !");
            }
            return deleteResult;
        }
        public Book GetBookById(int id)
        {
            var TargetBook = context.Books.Include(x => x.author).Include(x => x.Category).Include(x => x.Publisher).FirstOrDefault(x => x.Id == id);
            if(TargetBook != null)
            {
                return TargetBook;
            }
            throw new Exception("Error Occurs While Retrieve Book");
        }
    }
}
