using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

using System.Reflection;

using UnitOfWorkExample.Core.TestWeb;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddDbContext<DbContext, TDataContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
    , b => b.MigrationsAssembly(Assembly.GetEntryAssembly().GetName().ToString())));

await builder.Build().RunAsync();