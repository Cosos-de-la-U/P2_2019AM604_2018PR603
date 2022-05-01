using Microsoft.EntityFrameworkCore;
using P2_2019AM604_2018PR603.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddDbContext<dbCovidContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbCovidContext") ?? throw new InvalidOperationException());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Covid}/{action=Index}/{id?}");

app.Run();
