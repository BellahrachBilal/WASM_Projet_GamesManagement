using DemoWASM.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace DemoWASM.Pages.Exercices.GestionGame
{
    public partial  class DeleteGame
    {
        [Inject]
        HttpClient Client {  get; set; }
        [Inject]
        IJSRuntime JS {  get; set; }
        [Inject]
        NavigationManager nav {  get; set; }

        public List<Game> Games { get; set; } = new List<Game>();

        public async Task DeleteTheGame(int id)
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await Client.DeleteAsync($"Game/deletegame/{id}");

            if (response.IsSuccessStatusCode)
            {
                await LoadGames();
            }
            else
            {

                Console.WriteLine("Error deleting the game.");
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadGames();
        }

        private async Task LoadGames()
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Fetch the list of games from the API
            Games = await Client.GetFromJsonAsync<List<Game>>("Game");
        }


    }
}
