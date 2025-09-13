using Microsoft.EntityFrameworkCore;
using HabitHero.Models;

namespace HabitHero.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Habit> Habits { get; set; }
    }
}
