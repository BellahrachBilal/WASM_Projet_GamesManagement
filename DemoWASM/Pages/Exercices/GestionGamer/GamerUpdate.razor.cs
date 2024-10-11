using DemoWASM.Models;
using DemoWASM.Services;
using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.Exercices.GestionGamer
{
    public partial class GamerUpdate
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IGamerService Service { get; set; }
        public Gamer CurrentGamer { get; set; }

        [Parameter]
        public EventCallback NotifyUpdatedGamer { get; set; }
        protected override void OnParametersSet()
        {
            CurrentGamer = Service.GetById(Id);
        }

        public void OnValidSubmit()
        {
            Service.Update(CurrentGamer);
            NotifyUpdatedGamer.InvokeAsync();
            
        }
    }
}
