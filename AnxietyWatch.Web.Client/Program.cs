using AnxietyWatch.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<IAuthService, MockAuthService>();

await builder.Build().RunAsync();
