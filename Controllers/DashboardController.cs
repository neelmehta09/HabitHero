using HabitHero.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitHero.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly HabitHeroDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardController(HabitHeroDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var habits = await _context.Habits
                                       .Where(h => h.UserId == userId)
                                       .ToListAsync();
            return View(habits);
        }
    }
}
