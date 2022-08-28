using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class AuthorVM
    {

        [Required,MinLength(5,ErrorMessage ="At Least 5 Character !"),MaxLength(100,ErrorMessage ="At Most 100 Character !")]
        public string Name { get; set; }
        [Required,RegularExpression("[0-9]{4}",ErrorMessage ="Year Must 4 Digits")]
        public int BirthYear { get; set; }
    }
}
