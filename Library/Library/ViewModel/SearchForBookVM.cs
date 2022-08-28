using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class SearchForBookVM
    {
        [Required,MinLength(2),MaxLength(255)]
        public string SearchText { get; set; }
    }
}
