using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.ViewModel
{
    public class BorrowVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime HireDate { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [Remote(action: "CheckMaxDaysToHireBook", controller: "Borrow", AdditionalFields = "HireDate", ErrorMessage = "Max Period to hire a book is 30 Days !")]

        public DateTime RetrieveDate { get; set; }
    }
}
