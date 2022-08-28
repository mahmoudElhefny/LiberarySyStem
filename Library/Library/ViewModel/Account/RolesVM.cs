using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel.Account
{
    public class RolesVM
    {
        [Required,MinLength(2),MaxLength(30)]
        public string Name { get; set; }
    }
}
