using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Persistence;

public class PalindromeContext : DbContext
{
    public DbSet<PalindromeErgebnisDbo> PalindromeErgebnisse { get; set; }

    public PalindromeContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PalindromeErgebnisDbo>().HasKey(dbo => dbo.Eingabe); 
    }
}