using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public int PublishedYear { get; set; }
        public int Copies { get; set; }
        [NotMapped]
        public int BookAge { get
            {
                return DateTime.Now.Year - PublishedYear;
            } 
        }
        public int PagesCount { get; set; }
        public bool IsAvalable { get; set; }
        public string CoverImage { get; set; }
        public string Description { get; set; }
        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        [ForeignKey("Category")] 
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("author")]
        public int AuthorId { get; set; }
        public virtual Author author { get; set; }
        public virtual List<BorrowBooks> BorrowBooks { get; set; }  
        
    }
}
