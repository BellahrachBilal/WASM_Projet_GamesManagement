using DemoWASM.Models;
using DemoWASM.Services;
using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.Exercices.GestionGamer
{
    public partial class GamerDetail
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IGamerService Service { get; set; }
        public Gamer CurrentGamer { get; set; }

        protected override void OnParametersSet()
        {
            CurrentGamer = Service.GetById(Id);
        }
    }
}
