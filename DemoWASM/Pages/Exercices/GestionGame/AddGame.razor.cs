using DemoWASM.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace DemoWASM.Pages.Exercices.GestionGame
{
    public partial class AddGame
    {
        private Game game = new Game();
        [Inject] 
        HttpClient Client { get; set; }
        [Inject]
        IJSRuntime JS {  get; set; }
        [Inject]
        NavigationManager Nav {  get; set; } 

        public async Task AddingGame()
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await Client.PostAsJsonAsync("Game/addgame", game);
            if(response.IsSuccessStatusCode)
            {
                Nav.NavigateTo("/ListGames");
            }
            Console.WriteLine("Error Adding the game");
        }
    }
}
