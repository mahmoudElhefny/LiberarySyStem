using Library.Models;

namespace Library.Repositories.Authors
{
    public class AuthorRepsitory:IAuthorRepository
    {
        private readonly Context context;

        public AuthorRepsitory(Context _context) {
            context = _context;
        }
        public void AddAuthor(Author author)
        {
            if(author != null)
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }
        public Author findById(int id)
        {
           return context.Authors.FirstOrDefault(a => a.Id == id);
        }
        public List<Author> GetAuthors()
        {
            return context.Authors.ToList();
        }
        public void Edit(int id, Author author)
        {
            Author old_author = findById(id);
            if (old_author != null)
            {
                
                old_author.Name = author.Name;
                old_author.BirthYear = author.BirthYear;
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Author old_author = findById(id);
            if (old_author != null)
            {
                context.Authors.Remove(old_author);
                context.SaveChanges();
            }
        }
    }
}
