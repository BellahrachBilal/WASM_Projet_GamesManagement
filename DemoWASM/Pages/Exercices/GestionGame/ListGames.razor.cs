using DemoWASM.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace DemoWASM.Pages.Exercices.GestionGame
{
    public partial class ListGames
    {
        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public IJSRuntime JS {  get; set; }
        public List<Game> Games { get; set; }=new List<Game>();

        protected override async Task OnInitializedAsync()
        {
            await LoadGame();
        }

        public async Task LoadGame()
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Games = await Client.GetFromJsonAsync<List<Game>>("Game");
        }
    }
}
