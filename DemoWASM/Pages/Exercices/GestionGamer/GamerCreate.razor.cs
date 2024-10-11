using DemoWASM.Models;
using DemoWASM.Services;
using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.Exercices.GestionGamer
{
    public partial class GamerCreate
    {
        [Inject]
        public IGamerService Service { get; set; }

        [Parameter]
        public EventCallback NotifyNewGamer { get; set; }
        
        public Gamer GamerForm { get; set; }
        
        public GamerCreate()
        {
            GamerForm = new Gamer();
        }

        public void OnValidSubmit()
        {
            Service.Save(GamerForm);
            NotifyNewGamer.InvokeAsync();
            GamerForm = new Gamer();
        }
    }
}
