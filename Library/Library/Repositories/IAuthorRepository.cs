using Library.Models;
namespace Library
{
    public interface IAuthorRepository
    {
       void AddAuthor(Author author);
       Author findById(int id);
       List<Author> GetAuthors();
       void Edit(int id, Author author);
       void Delete(int id);
    
    
    }
}
