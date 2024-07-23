using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.CommentAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastructure.EFCore.Mapping;

namespace ShopManagement.Infrastructure.EFCore
{
    public class ShopContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductCategoryMapping).Assembly)
                .ApplyConfigurationsFromAssembly(typeof(ProductMapping).Assembly)
                .ApplyConfigurationsFromAssembly(typeof(ProductPictureMapping).Assembly)
                .ApplyConfigurationsFromAssembly(typeof(SlideMapping).Assembly)
                .ApplyConfigurationsFromAssembly(typeof(CommentMapping).Assembly); ;
     

            base.OnModelCreating(modelBuilder);
        }

    }
}
