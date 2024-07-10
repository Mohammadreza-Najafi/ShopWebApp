using DiscountManagement.Configuration;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Configuration;
using ShopManagement.Infrastructure.EFCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ShopDB");

builder.Services.AddDbContext<ShopContext>(options => options.UseSqlServer(connectionString));

ShopManagementBootstrapper.Configure(builder.Services, connectionString);
DiscountManagementBootstrapper.Configure(builder.Services, connectionString);

builder.Services.AddRazorPages();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
