using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class PublisherVM
    {
        [Required, MinLength(2, ErrorMessage = "At Least 2 Character !"), MaxLength(100, ErrorMessage = "At Most 100 Character !")]
        public string Name { get; set; }
        [Required, RegularExpression("[0-9]{11}", ErrorMessage = "phone Number Must 11 Digits")]
        public string Phone { get; set; }
        [Required, RegularExpression("[0-9]{4}", ErrorMessage = "Year Must 4 Digits")]
        public int StablishedAt { get; set; }
    }
}
