using System.ComponentModel.DataAnnotations;

namespace HabitHero.Models
{
    public class Habit
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? LastCompletedDate { get; set; }

        public int CurrentStreak { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
    }
}
