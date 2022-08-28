using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.ViewModel.Account
{
    public class RegisterVM
    {
        [Required]
        public string UserName { get; set; }
        [Required,MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password"),Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("[0-9]{11}", ErrorMessage = "Phone Number Must Be 11 Digit!"), Required]
        public string Phone { get; set; }
        public string Gender { get; set; }
        [Column(TypeName ="Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress),Required]
        [MaxLength(50),MinLength(10)]
        public string Email { get; set; }

    }
}
