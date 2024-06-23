using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ShopDB");
builder.Services.AddDbContext<ShopContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddRazorPages();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
