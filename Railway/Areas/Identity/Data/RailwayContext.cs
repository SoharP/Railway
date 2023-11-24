using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Railway.Areas.Identity.Data;
using Railway.Models;

namespace Railway.Areas.Identity.Data;

public class RailwayContext : IdentityDbContext<RailwayUser>
{
    public RailwayContext(DbContextOptions<RailwayContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Railway.Models.Routed> Routed { get; set; } = default!;

    public DbSet<Railway.Models.Station> Station { get; set; } = default!;

    public DbSet<Railway.Models.Train> Train { get; set; } = default!;

public DbSet<Railway.Models.Schedule> Schedule { get; set; } = default!;

public DbSet<Railway.Models.City> City { get; set; } = default!;

public DbSet<Railway.Models.Platform> Platform { get; set; } = default!;

public DbSet<Railway.Models.Weekdays> Weekdays { get; set; } = default!;
}
