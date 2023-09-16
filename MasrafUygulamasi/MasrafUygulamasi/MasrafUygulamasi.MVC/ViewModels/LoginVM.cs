using System.ComponentModel.DataAnnotations;

namespace MasrafUygulamasi.MVC.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "This place must be filled")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This place must be filled")]
        public string Password { get; set; }
    }
}
