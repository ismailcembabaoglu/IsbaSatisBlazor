using Blazored.LocalStorage;
using Blazored.Modal;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Server.Middlewares;
using IsbaSatisBlazor.Server.Services.Extensions;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Server.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddBlazoredModal();

builder.Services.ConfigureMapping();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpContextAccessor>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductGroupService, ProductGroupService>();
builder.Services.AddDbContext<IsbaSatisDbContext>(config =>
{
    config.UseSqlServer("Server=DESKTOP-SLOIL0F;Database=IsbaSatisBlazorTest3;User Id=sa;Password=17421742;TrustServerCertificate=True;");
    config.EnableSensitiveDataLogging();
});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["JwtIssuer"],
        ValidAudience = configuration["JwtAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]))
    };
});


builder.Services.AddBlazoredLocalStorage();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
