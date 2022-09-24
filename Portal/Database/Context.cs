using Microsoft.EntityFrameworkCore;
using Portal.Database.Tables;
using Portal.Plugins;

namespace Portal.Database;

public class Context : DbContext
{
    public DbSet<IgnoreMe> IgnoreMe { get; set; }
    public DbSet<Pipeline> Pipelines { get; set; }
    public DbSet<Plugin> Plugins { get; set; }
    public DbSet<FilterPlugin> FilterPlugins { get; set; }

    public Context(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FilterPlugin>().ToTable("FilterPlugins");
    }
}

public class IgnoreMe
{
    public int Id { get; set; }
    public string Username { get; set; }
}