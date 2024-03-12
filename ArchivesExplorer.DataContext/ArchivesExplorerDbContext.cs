using ArchivesExplorer.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ArchivesExplorer.DataContext
{
    public class ArchivesExplorerDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ArchivesExplorerDbContext(DbContextOptions<ArchivesExplorerDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
