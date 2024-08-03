using _0_Framwork.Application;
using BlogManagement.Infrastructure.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Configuration;
using ShopManagement.Infrastructure.EFCore;
using ShopWebApp;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ShopDB");

//builder.Services.AddDbContext<ShopContext>(options => options.UseSqlServer(connectionString));

ShopManagementBootstrapper.Configure(builder.Services, connectionString);
DiscountManagementBootstrapper.Configure(builder.Services, connectionString);
InventoryManagementBootstrapper.Configure(builder.Services, connectionString);
BlogManagementBootstrapper.Configure(builder.Services, connectionString);

builder.Services.AddTransient<IFileUploader,FileUploader>();

builder.Services.AddRazorPages();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
