using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class BookVM
    {
        [Required,Range(10000,999999999,ErrorMessage ="Invalid ISBN : Must At Least 5 Digits, At Most 9 Digits")]
        public int ISBN { get; set; }
        [Required,MinLength(2,ErrorMessage ="Minimum 2 charachters"),MaxLength(255, ErrorMessage = "Maximum 255 charachters")]
        public string Title { get; set; }
        [Required,RegularExpression("[0-9]{4}",ErrorMessage ="Invalid Year , Year Must 4 digits !")]
        public int PublishedYear { get; set; }
        [Required]
        public int Copies { get; set; }
        [Required,MaxLength(30,ErrorMessage ="At Most 30 character")]
        public string Version { get; set; }
        [Required]
        public int PagesCount { get; set; }
        public bool IsAvalable { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }

        public AuthorCategoryPublisherVM? AuthorCategoryPublisherVM { get; set; }

        //public string CoverImage { get; set; }
        public IFormFile ImageFile { get; set; }
        [Required, MinLength(10),MaxLength(1024)]
        public string Description { get; set; }

    }
}
