using DemoWASM.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace DemoWASM.Pages.Exercices.GestionGame
{
    public partial class UpdateGame
    {

        private List<Game> games = new List<Game>();
        public int selectedGameId; 

        public Game game =  new Game();
        [Inject]
        HttpClient Client { get; set; }
        [Inject]
        IJSRuntime JS { get; set; }
        [Inject]
        NavigationManager Nav { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadGames();
        }

        private async Task LoadGames()
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            games = await Client.GetFromJsonAsync<List<Game>>("Game");

        }
        private void OnGameSelected(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out selectedGameId) && selectedGameId > 0)
            {
                var selectedGame = games.FirstOrDefault(g => g.Id == selectedGameId);
                if (selectedGame != null)
                {

                    game.Title = selectedGame.Title;
                    game.ReleaseYear = selectedGame.ReleaseYear;
                    game.Synopsis = selectedGame.Synopsis;
                }
            }
            else
            {
                game = new Game();
            }
        }
        public async Task UpdateSubmit()
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var res = await Client.PutAsJsonAsync($"Game/updategame/{game.Id}", game);
            if (res.IsSuccessStatusCode)
            {
                Nav.NavigateTo("/ListGames");
            }
            else
            {
                Console.WriteLine("Error updating the game.");
            }
        }



    }
}
