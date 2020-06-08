using Microsoft.EntityFrameworkCore;
using ShareEverything.Models;

namespace ShareEverything.Persistence
{
    public class SharedLinksContext : DbContext
    {
        public SharedLinksContext(DbContextOptions<SharedLinksContext> options)
            : base(options)
        {}

        public DbSet<SharedLink> SharedLinks { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SharedLinkTag>()
                .HasKey(slt => new { slt.SharedLinkId, slt.TagId });
        }
    }
}