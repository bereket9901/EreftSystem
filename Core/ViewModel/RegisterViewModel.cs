using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.ViewModel
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            Roles = new List<string>();
        }

        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public IList<string> Roles { get; set; }    

    }
}
