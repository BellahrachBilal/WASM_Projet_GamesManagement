using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.Exercices.QuizzExo
{
    public partial class Quizz
    {
        [Parameter]
        public string Question { get; set; }

        [Parameter]
        public string Prenom { get; set; }
        [Parameter]
        public int NumQuestion { get; set; }

        [Parameter]
        public EventCallback<string> ReponseEvent { get; set; }

        public void Repondre(string rep)
        {
            ReponseEvent.InvokeAsync(rep);
        }
    }
}
