using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Speaker> Speakers => Set<Speaker>();

        public DbSet<BackEnd.Models.Session> Session { get; set; } = default!;

        public DbSet<BackEnd.Models.Attendee> Attendee { get; set; } = default!;
    }
}