using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class BorrowBooks
    {
        public int Id { get; set; }
        [Column(TypeName ="Date"),Required]
        public DateTime HireDate { get; set; }
        [Column(TypeName ="Date"),Required]
        [Remote(action:"CheckMaxDaysToHireBook",controller:"Borrow",AdditionalFields = "HireDate",ErrorMessage ="Max Period to hire a book is 30 Days !")]
        public DateTime RetrieveDate { get; set; }
        public bool IsRetrived { get; set; }

        //[ForeignKey("Books"),Required]
        public string BookTitle { get; set; }
        //public virtual Book Books { get; set; }

        //[ForeignKey("Users"),Required]
        public string UserName { get; set; }
        //public virtual ApplicationUser Users { get; set; }
        
    }
}
