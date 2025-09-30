using Microsoft.EntityFrameworkCore;
public class RedirectDbContext : DbContext
{
    public RedirectDbContext(DbContextOptions<RedirectDbContext> options)
        : base(options) { }

    public DbSet<RedirectEntry> RedirectEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RedirectEntry>()
            .HasIndex(r => r.ShortUri)
            .IsUnique();
    }
}
