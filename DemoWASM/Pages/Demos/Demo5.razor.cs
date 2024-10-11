using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Xml;

namespace DemoWASM.Pages.Demos
{
    public partial class Demo5
    {
        [Inject]
        public IJSRuntime JS { get; set; }

        private IJSObjectReference jsModule;

        protected override async Task OnInitializedAsync()
        {
            jsModule = await JS.InvokeAsync<IJSObjectReference>("import", "./script/monscript.js");
        }

        public string InfoFromStorage { get; set; }
        public async Task SaveInfo()
        {
            await JS.InvokeVoidAsync("localStorage.setItem", "moninfo", JsonSerializer.Serialize( new { name = "Arthur", subject = "Pomme" }));
            await jsModule.InvokeVoidAsync("maFonction");
        
        }

        public async Task GetInfo()
        {
            InfoFromStorage = await JS.InvokeAsync<string>("localStorage.getItem", "moninfo");
        }

        public async Task CallJSWithObject()
        {
            await jsModule.InvokeVoidAsync("withObject", new { name = "Arthur", subject = "Pomme" });
        }
    }
}
