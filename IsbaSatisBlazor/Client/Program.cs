using Blazored.LocalStorage;
using Blazored.Modal;
using IsbaSatisBlazor.Client;
using IsbaSatisBlazor.Client.Utils;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Morris.Blazor.Validation;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ModalManager>();

builder.Services.AddBlazoredModal();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(ProductDTO).Assembly));
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
