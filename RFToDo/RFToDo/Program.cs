using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Radzen;
using RFToDo.Client.Pages;
using RFToDo.Components;
using RFToDo.Shared.Data;
using RFToDo.Shared.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using RFToDo.Client.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddScoped(http => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!) });
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGoalService, GoalService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ISweetAlertMessage, SweetAlertMessage>();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddRadzenComponents();
builder.Services.AddTransient<DialogService>();
builder.Services.AddSweetAlert2();
builder.Services.AddSingleton(sp =>
{
    // Get the address that the app is currently running at
    var server = sp.GetRequiredService<IServer>();
    var addressFeature = server.Features.Get<IServerAddressesFeature>();
    string baseAddress = addressFeature!.Addresses.First();
    return new HttpClient { BaseAddress = new Uri(baseAddress) };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(RFToDo.Client._Imports).Assembly);

app.Run();
