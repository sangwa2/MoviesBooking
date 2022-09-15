using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoviesApp;
using MoviesApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// 118,  

builder.Services.AddHttpClient<IMovies, MovieService>(client => {
    client.BaseAddress = new Uri("https://localhost:7251");
});
builder.Services.AddScoped<HttpClient>();
builder.Services.AddHttpClient<IBookings, BookingService>(client => {
    client.BaseAddress = new Uri("https://localhost:7251");
});


builder.Services.AddHttpClient<IBookings, BookingService>(client => {
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});


await builder.Build().RunAsync();
