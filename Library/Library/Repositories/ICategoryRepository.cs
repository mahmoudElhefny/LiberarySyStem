using Library.Models;

namespace Library
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
