using Microsoft.EntityFrameworkCore;

namespace Portal.Database;

public class Context : DbContext
{
    public DbSet<RawDbSet> Raw { get; set; }
    public DbSet<IgnoreMe> IgnoreMe { get; set; }

    public Context(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RawDbSet>().HasNoKey();
    }
}

public class RawDbSet
{
}

public class IgnoreMe
{
    public int Id { get; set; }
    public string Username { get; set; }
}