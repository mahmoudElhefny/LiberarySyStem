using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[Column(TypeName ="Date")]
        //public DateOnly BirthYear { get; set; }
        public int BirthYear { get; set; }
        public virtual ICollection<Book> books { get; set; }
    }
}
