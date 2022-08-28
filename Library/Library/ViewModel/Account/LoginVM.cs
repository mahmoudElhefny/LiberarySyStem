using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel.Account
{
    public class LoginVM
    {
        
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password),Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
