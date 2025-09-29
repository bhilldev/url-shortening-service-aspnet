using Microsoft.EntityFrameworkCore;

public class RedirectDbContext : DbContext
{
    public RedirectDbContext(DbContextOptions<RedirectDbContext> options)
        : base(options) { }

    public DbSet<RedirectEntry> RedirectEntries { get; set; }
}

