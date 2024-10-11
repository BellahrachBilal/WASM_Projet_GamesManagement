using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace DemoWASM.Pages.Demos.Auth
{
    public partial class Login
    {
        public LoginForm form { get; set; } = new LoginForm();

        [Inject]
        public HttpClient Client { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }
        [Inject]
        public AuthenticationStateProvider StateProvider { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }


        public async Task SubmitForm()
        {
            HttpResponseMessage response = 
                await Client.PostAsJsonAsync("user/login", form);

            if (!response.IsSuccessStatusCode)
            {
                await Console.Out.WriteLineAsync("Erreur : " + response.ReasonPhrase);
            }

            string token = await response.Content.ReadAsStringAsync();
            await JS.InvokeVoidAsync("localStorage.setItem", "token", token);
            ((MyStateProvider)StateProvider).NotifyUserChanged();
            Nav.NavigateTo("/");
        }
    }
}
