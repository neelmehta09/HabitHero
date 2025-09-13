using System;
using System.ComponentModel.DataAnnotations;

namespace HabitHero.Models
{
	public class Habit
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime StartDate { get; set; } = DateTime.Now;

		public int StreakCount { get; set; } = 0;

		public bool IsCompletedToday { get; set; } = false;
	}
}
