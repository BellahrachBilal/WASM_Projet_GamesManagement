using System.ComponentModel.DataAnnotations;

namespace DemoWASM.Models
{
    public class Jeu
    {
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }
        public string Genre { get; set; }
        [Range(1980, 2025)]
        public int AnneeSortie { get; set; }
        [MinLength(20)]
        public string Description { get; set; }
    }
}
