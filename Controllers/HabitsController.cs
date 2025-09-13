using HabitHero.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitHero.Controllers
{
    public class HabitsController : Controller
    {
        private readonly HabitHeroDbContext _db;

        public HabitsController(HabitHeroDbContext db)
        {
            _db = db;
        }

        // GET: Habits
        public async Task<IActionResult> Index()
        {
            var habits = await _db.Habits.ToListAsync();
            return View(habits);
        }

        // GET: Habits/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var habit = await _db.Habits.FirstOrDefaultAsync(h => h.Id == id);
            if (habit == null) return NotFound();
            return View(habit);
        }

        // GET: Habits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habits/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Habit habit)
        {
            if (ModelState.IsValid)
            {
                _db.Habits.Add(habit);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habit);
        }

        // GET: Habits/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var habit = await _db.Habits.FindAsync(id);
            if (habit == null) return NotFound();
            return View(habit);
        }

        // POST: Habits/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Habit habit)
        {
            if (id != habit.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _db.Update(habit);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habit);
        }

        // GET: Habits/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var habit = await _db.Habits.FindAsync(id);
            if (habit == null) return NotFound();
            return View(habit);
        }

        // POST: Habits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habit = await _db.Habits.FindAsync(id);
            if (habit != null)
            {
                _db.Habits.Remove(habit);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
