using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); //overriden

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(connectionString));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(
    policy=>
    policy.WithOrigins("http://localhost:7193", "https://localhost:7193")
    .AllowAnyMethod()
   
    );


app.UseHttpsRedirection();

app.UseRouting();// custom

//start custom
app.UseAuthorization();
app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapDefaultControllerRoute();
//app.MapBlazorHub();

//End custom


app.MapControllers();
 



app.Run();
