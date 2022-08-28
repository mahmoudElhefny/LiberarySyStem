using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class Context:IdentityDbContext<ApplicationUser>
    {
        public Context():base()
        {

        }
        public Context(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Library;Integrated security=true;");
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
            
        //}
        public  DbSet<Book> Books { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<Author> Authors { get; set; }
        public  DbSet<Publisher> Publishers { get; set; }
        public DbSet<BorrowBooks> borrowBooks { get; set; }
        public DbSet<WishList> WishLists { get; set; }

    }
}
