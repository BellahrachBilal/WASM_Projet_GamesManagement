using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace DemoWASM.Pages.Demos.Auth
{
    public class MyStateProvider(IJSRuntime JS) : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");

            if(!string.IsNullOrEmpty(token)) 
            {
                JwtSecurityToken jwt = new JwtSecurityToken(token);
                ClaimsIdentity currentUser = new ClaimsIdentity(jwt.Claims, "JwtAuth");
                //await Console.Out.WriteLineAsync(JsonConvert.SerializeObject(currentUser.Claims.First(x => x.Type == ClaimTypes.Role).Value));

                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(currentUser)));
            }

            ClaimsIdentity anonymous = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }

        public void NotifyUserChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
