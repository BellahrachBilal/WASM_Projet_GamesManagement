using DemoWASM.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace DemoWASM.Pages.Demos
{
    public partial class Demo6
    {
        [Inject]
        public HttpClient Client { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        public List<User> Liste { get; set; } = new List<User>();

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        public async Task LoadData()
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Liste = await Client.GetFromJsonAsync<List<User>>("User");

            //using (HttpClient client = Client)
            //{
            //    using (HttpResponseMessage resp = await client.GetAsync("User"))
            //    {
            //        if (resp.IsSuccessStatusCode)
            //        {

            //            string json = await resp.Content.ReadAsStringAsync();

            //            Liste = JsonSerializer.Deserialize<List<User>>(json);
            //        }
            //    }
            //}
        }
    }
}
