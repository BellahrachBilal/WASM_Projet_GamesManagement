using System.ComponentModel.DataAnnotations;

namespace DemoWASM.Pages.Demos.Auth
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
