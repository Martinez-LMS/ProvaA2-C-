using Microsoft.EntityFrameworkCore;

namespace Leonardo.Models;

public class AppDataContext : DbContext
{
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<imc> imc { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=leonardo.db");
    }
}