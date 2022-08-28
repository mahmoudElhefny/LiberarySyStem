using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class CategroyVM
    {
        [Required, MinLength(2, ErrorMessage = "At Least 2 Character !"), MaxLength(100, ErrorMessage = "At Most 100 Character !")]
        public string Name { get; set; }
    }
}
