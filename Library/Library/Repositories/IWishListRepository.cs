using Library.Models;

namespace Library.Repositories
{
    public interface IWishListRepository
    {
        bool Add(WishList model);
        bool remove(int id);
        List<Book> GetAll(string UserId);
        bool IsBookInWishListOfCurrentUser(string userId, int bookId);
    }
}
