using Library.Models;
using Library.ViewModel;

namespace Library.Repositories
{
    public interface IBookRepository
    {
        bool Add(BookVM bookVM);
        BookVM GetUpdate(int id);
        void SaveUpdate(int id,BookVM model);
        void addBook(BookVM bookVM);
        List<Book> ShowAll(); 
        bool deleteBook(int id);
        Book GetBookById(int id);
        
    }
}
