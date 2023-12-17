using Blazored.LocalStorage;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Radzen;
using System.Security.Claims;

namespace IsbaSatisBlazor.Client.Utils
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorageService;
        private readonly HttpClient client;
        private readonly AuthenticationState anonymous;
        //private readonly IsbaSatisDbContext context;

        public AuthStateProvider(ILocalStorageService LocalStorageService, HttpClient Client/*IsbaSatisDbContext _context*/)
        {
            //context = _context;
            localStorageService = LocalStorageService;
            client = Client;
            anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            String apiToken = await localStorageService.GetItemAsStringAsync("token");

            if (String.IsNullOrEmpty(apiToken))
                return anonymous;
            

            String email = await localStorageService.GetItemAsStringAsync("email");
            List<UserRoleDTO> roles = await localStorageService.GetItemAsync<List<UserRoleDTO>>("userRoles");
            //var userRoles = context.UserRoles.Include(c => c.Users).Where(c => c.Users.EMailAddress == email);
            //var claims = new List<Claim>();
            //claims.Add(new Claim(ClaimTypes.Email, email));
            //foreach (var item in userRoles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, item.RoleType.ToString()));
            //}
            List<Claim> claims=new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, email));
            if (roles!=null)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.RoleType.ToString()));
                }
            }
            var cp = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwtAuthType"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiToken);

            return new AuthenticationState(cp);
        }

        public void NotifyUserLogin(String email,IEnumerable<UserRoleDTO>userRoles)
        {
            List<Claim>cl= new List<Claim>();
            cl.Add(new Claim(ClaimTypes.Email, email));
            if (userRoles != null)
            {
                foreach (var role in userRoles)
                {
                    cl.Add(new Claim(ClaimTypes.Role, role.RoleType.ToString()));
                }
            }
            var cp = new ClaimsPrincipal(new ClaimsIdentity(cl, "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(cp));

            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
