using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        //public virtual List<BorrowBooks> BorrowBooks { get; set; }
        public virtual List<WishList> WishLists { get; set; }
    }
}
