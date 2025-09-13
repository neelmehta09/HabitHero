using HabitHero.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitHero.Controllers
{
    [Authorize]
    public class HabitsController : Controller
    {
        private readonly HabitHeroDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HabitsController(HabitHeroDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var habits = _context.Habits.Where(h => h.UserId == userId).ToList();
            return View(habits);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Habit habit)
        {
            habit.UserId = _userManager.GetUserId(User);
            _context.Add(habit);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Habit created successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            if (habit == null || habit.UserId != _userManager.GetUserId(User))
                return NotFound();
            return View(habit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Habit habit)
        {
            habit.UserId = _userManager.GetUserId(User);
            _context.Update(habit);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Habit updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            if (habit == null || habit.UserId != _userManager.GetUserId(User))
                return NotFound();
            return View(habit);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            if (habit != null)
            {
                _context.Habits.Remove(habit);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Habit deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ToggleCompletion(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            if (habit != null && habit.UserId == _userManager.GetUserId(User))
            {
                if (habit.LastCompletedDate == DateTime.Today)
                {
                    habit.CurrentStreak = Math.Max(0, habit.CurrentStreak - 1);
                    habit.LastCompletedDate = null;
                }
                else
                {
                    habit.CurrentStreak++;
                    habit.LastCompletedDate = DateTime.Today;
                }
                _context.Update(habit);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
