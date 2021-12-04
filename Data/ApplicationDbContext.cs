using System.Reflection;
using hey_istanbul_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace hey_istanbul_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<FavoriteEntity> Favorites { get; set; }
    }
}