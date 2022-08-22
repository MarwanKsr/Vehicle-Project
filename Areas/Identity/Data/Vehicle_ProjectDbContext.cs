using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vehicl_Project.Areas.Identity.Data;
using Vehicl_Project.Models;

namespace Vehicl_Project.Areas.Identity.Data;

public class Vehicle_ProjectDbContext : IdentityDbContext<Vehicle_ProjectUser>
{
    public Vehicle_ProjectDbContext(DbContextOptions<Vehicle_ProjectDbContext> options)
        : base(options)
    {
    }

    public DbSet<Color> Colors { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Boat> Boats { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<Color>().HasData(
           new Color() { Id = 1, Name = "Red" },
           new Color() { Id = 2, Name = "Blue" },
           new Color() { Id = 3, Name = "Black" },
           new Color() { Id = 4, Name = "White" }
           );
    }
}
