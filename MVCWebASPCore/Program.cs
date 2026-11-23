using Microsoft.EntityFrameworkCore;
using MVCWebASPCore.Data;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("http://localhost:5191");

builder.WebHost.UseUrls("http://0.0.0.0:8080");//docker contenedor

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<dbFirstContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
