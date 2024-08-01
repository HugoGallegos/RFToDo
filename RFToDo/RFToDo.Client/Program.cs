using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using RFToDo.Client.Helpers;
using RFToDo.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<IGoalService, ClientGoalService>();
builder.Services.AddScoped<ITaskService, ClientTaskService>();
builder.Services.AddTransient<DialogService>();
builder.Services.AddScoped(http => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSweetAlert2();
builder.Services.AddTransient<DialogService>();
builder.Services.AddScoped<ISweetAlertMessage, SweetAlertMessage>();
await builder.Build().RunAsync();
