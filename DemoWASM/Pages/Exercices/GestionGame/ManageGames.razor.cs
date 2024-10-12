using DemoWASM.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace DemoWASM.Pages.Exercices.GestionGame
{
    public partial class ManageGames
    {
        [Inject]
        HttpClient Client { get; set; }
        [Inject]
        IJSRuntime JS {  get; set; }
        [Inject]
        NavigationManager Nav { get; set; }

        private List<Game> games = new List<Game>();
        private Game selectedGame = new Game();
        private Game game = new Game();
        private bool isUpdating = false;

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

        private void EditGame(Game gametoedit )
        {
            selectedGame = gametoedit; 
            game = new Game 
            {
                Id = selectedGame.Id,
                Title = selectedGame.Title,
                ReleaseYear = selectedGame.ReleaseYear,
                Synopsis = selectedGame.Synopsis
            };
            isUpdating = true;
        }
        private async Task DeleteGame(Game gameToDelete)
        {
            if (gameToDelete != null)
            {
                // Call the method to delete the game
                await DeleteTheGame(gameToDelete.Id);
                selectedGame = null; // Clear selected game after deletion
            }
        }


        public async Task DeleteTheGame(int id)
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await Client.DeleteAsync($"Game/deletegame/{id}");

            if (response.IsSuccessStatusCode)
            {
                await LoadGames(); // Refresh the list of games after deletion
            }
            else
            {
                Console.WriteLine("Error deleting the game.");
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error details: {errorMessage}"); // Log error details
            }
        }

        private async Task HandleSubmit()
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            if (isUpdating)
            {
                //update
                var res = await Client.PutAsJsonAsync($"Game/updategame/{game.Id}", game);
               
                if (res.IsSuccessStatusCode)
                {
                    var updatedGame = games.FirstOrDefault(g => g.Id == game.Id);
                    if (updatedGame != null)
                    {
                        updatedGame.Title = game.Title;
                        updatedGame.ReleaseYear = game.ReleaseYear;
                        updatedGame.Synopsis = game.Synopsis;
                    }
                    ClearForm();
                }
            }
            else
            {
                // Add new game
                var res = await Client.PostAsJsonAsync("Game/addgame", game);
                if (res.IsSuccessStatusCode)
                {
                    await LoadGames();
                    ClearForm();
                }
            }
        }
        private void ClearForm()
        {
            game = new Game();
            isUpdating = false;
            selectedGame = null;
        }
    }
}
