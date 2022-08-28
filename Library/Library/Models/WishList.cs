using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class WishList
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }//id is string as id in identityUser is string
        public virtual ApplicationUser? User { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
    }
}
