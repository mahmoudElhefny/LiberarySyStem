using Library.Models;
using Library.ViewModel;

namespace Library.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        Category findById(int id);
        List<Category> GetCategories();
        void Edit(int id, Category category);
        void Delete(int id);
    }
}
