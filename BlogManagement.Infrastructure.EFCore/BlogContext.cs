using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore
{
    public class BlogContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) 
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ArticleCategoryMapping).Assembly)
                .ApplyConfigurationsFromAssembly(typeof(ArticleMapping).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
