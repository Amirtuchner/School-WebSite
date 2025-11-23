using Microsoft.EntityFrameworkCore;
using School_Site.Model;

namespace School_Site.Dal
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<SiteText> SiteTexts => Set<SiteText>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SiteText>()
                .HasIndex(t => new { t.Key, t.Language })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }

}
