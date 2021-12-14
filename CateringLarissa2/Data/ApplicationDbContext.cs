using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CateringLarissa2.Models;

namespace CateringLarissa2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
#pragma warning disable CS8618 // Non-nullable property 'Review' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Menu' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
#pragma warning restore CS8618 // Non-nullable property 'Menu' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning restore CS8618 // Non-nullable property 'Review' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
            : base(options)
        {
        }
        public DbSet<CateringLarissa2.Models.Menu> Menu { get; set; }
        public DbSet<CateringLarissa2.Models.Review> Review { get; set; }
        public DbSet<CateringLarissa2.Models.Pesan> Pesan { get; set; }
    }
}