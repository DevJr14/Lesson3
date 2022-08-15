using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using UI;
using UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{ 
    BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseApiUrl")) 
});

builder.Services.AddMudServices();
builder.Services.AddScoped<IStudentService, StudentService>();

await builder.Build().RunAsync();
