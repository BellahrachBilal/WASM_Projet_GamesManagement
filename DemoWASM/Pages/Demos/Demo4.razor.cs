using DemoWASM.Models;
using System.Text.Json;

namespace DemoWASM.Pages.Demos
{
    public partial class Demo4
    {
        public Jeu JeuForm { get; set; }

        public List<string> Genres { get; set; }
        public Demo4()
        {
            JeuForm = new Jeu();
            JeuForm.Titre = "bidule";
            Genres = new List<string>();
            Genres.AddRange(new string[] {"RPG", "RTS", "FPS", "Hack'n slash", "Autre" });
        }

        public void SubmitForm()
        {
            Console.WriteLine(JsonSerializer.Serialize(JeuForm));
        }
    }
}
