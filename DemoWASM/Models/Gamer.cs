using System.ComponentModel.DataAnnotations;

namespace DemoWASM.Models
{
    public class Gamer
    {
        public int Id { get; set; }
        [Required]
        public string Pseudo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }

        public DateTime BirthDate  { get; set; }
    }
}
