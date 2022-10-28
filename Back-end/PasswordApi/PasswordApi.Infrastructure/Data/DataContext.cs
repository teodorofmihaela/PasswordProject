using Microsoft.EntityFrameworkCore;
using PasswordApi.Core.Models;

namespace PasswordApi.Infrastructure.Data;

public class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    
    public DbSet<TemporaryPassword> TemporaryPasswords { get; set; }
    
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .HasOne(s => s.TemporaryPassword)
            .WithOne(t => t.Account)
            .HasForeignKey<Account>(t => t.TemporaryPasswordId);
    }
}