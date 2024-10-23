using backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
public class FlowboardContext : IdentityDbContext<User>
{
    public DbSet<User> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=12Sand3457e5;Database=Flowboard;",
        //option.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=Tvufgs!;Database=Flowboard;",
        option => option.EnableRetryOnFailure());
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     modelBuilder
     .Entity<User>()
     .HasKey(u => u.Id);
     base.OnModelCreating(modelBuilder);
    }
}