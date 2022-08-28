using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories
{
    public class WishListRepository : IWishListRepository
    {
        private readonly Context context;

        public WishListRepository(Context context)
        {
            this.context = context;
        }
        public bool Add(WishList model)
        {
            try { 
                context.WishLists.Add(model);
                context.SaveChanges();
                return true;
            }
            catch
            {
                throw new InvalidDataException("Unable To Add To WishList");
            }
        }

        public bool remove(int id)
        {
            var book = context.WishLists.Include(x=>x.Book).FirstOrDefault(x => x.Book.Id == id);
            if(book != null) { 
            context.WishLists.Remove(book);
            context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Book> GetAll(string UserId)
        {
            
            List<Book> books = new List<Book>();
            List<WishList> wishlist = context.WishLists.Where(x=>x.UserId == UserId).ToList();
            foreach (var item in wishlist) {
               Book book = context.Books.Include(x=>x.author).FirstOrDefault(x => x.Id == item.BookId);
                if (book != null) { 
                 books.Add(book); 
                }
            }
            return books;
        }
        public bool IsBookInWishListOfCurrentUser(string userId,int bookId)
        {
            
            List<Book> booksOFCurrentUserInHisWishList = GetAll(userId);
            if (booksOFCurrentUserInHisWishList != null) {
                foreach(Book item in booksOFCurrentUserInHisWishList)
                {
                    if(item.Id == bookId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
