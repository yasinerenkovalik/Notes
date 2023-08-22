using Microsoft.EntityFrameworkCore;
using Notes.Domail;
using Notes.Persistence.DTOs;

namespace Notes.Persistence.Repository;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=postgres;Pooling=true;Connection Lifetime=0;");
    }
    
    public DbSet<User> Users { get; set; }

    public DbSet<Note> Notes { get; set; }
    public DbSet<UserDTO> UserDtos { get; set; }



}