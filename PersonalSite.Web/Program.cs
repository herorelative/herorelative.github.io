using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PersonalSite.Web;
using PersonalSite.Web.Services;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("static", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddHttpClient("quote", client =>
{
    client.BaseAddress = new Uri("https://api.quotable.io");
});

builder.Services.AddScoped<IStaticFileService, StaticFileService>();
builder.Services.AddScoped<IQuoteService, QuoteService>();

builder.Services.Configure<StaticFileOptions>(options =>
{
    options.OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers
        .TryAdd("Cache-Control", "public,max-age=2592000");
        ctx.Context.Response.Headers
        .TryAdd("Expires", DateTime.UtcNow.AddDays(30).ToString("R", CultureInfo.InvariantCulture));
    };
});

await builder.Build().RunAsync();
