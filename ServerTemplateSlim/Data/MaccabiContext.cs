using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServerTemplateSlim.Model;

namespace ServerTemplateSlim.Data
{
    public class MaccabiContext : IdentityDbContext<MaccabiUser>
    {
        public DbSet<MaccabiUser> MaccabiUsers { get; set; }

        public DbSet<VideoCategory> VideoCategories { get; set; }

        public DbSet<VideoLink> VideoLinks { get; set; }


        public MaccabiContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<MaccabiUser>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<VideoCategory>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });
        }

    }
}
