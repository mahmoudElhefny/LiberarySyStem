using Library.Models;

namespace Library.Repositories.CategoryRepository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly Context context;

        public CategoryRepository(Context _context)
        {
            context = _context;
        }
        public void AddCategory(Category category)
        {
            if (category != null)
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        public Category findById(int id)
        {
            return context.Categories.FirstOrDefault(a => a.Id == id);
        }
        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
        public void Edit(int id, Category category)
        {
            Category old_category = findById(id);
            if (old_category != null)
            {
               
                old_category.Name = category.Name;
               
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Category old_category = findById(id);
            if (old_category != null)
            {
                context.Categories.Remove(old_category);
                context.SaveChanges();
            }
        }
    }
}
