using Microsoft.EntityFrameworkCore;
using Notes.Domail;

namespace Notes.Persistence;

public class Context:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Notes;Pooling=true;Connection Lifetime=0;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Notes)
            .WithOne(n=>n.User);
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Note> Notes { get; set; }
  


}