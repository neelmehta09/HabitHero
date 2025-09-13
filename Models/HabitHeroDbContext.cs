using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HabitHero.Models
{
    public class HabitHeroDbContext : IdentityDbContext<IdentityUser>
    {
        public HabitHeroDbContext(DbContextOptions<HabitHeroDbContext> options)
            : base(options) { }

        public DbSet<Habit> Habits { get; set; } = null!;
    }
}
