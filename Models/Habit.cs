using System;
using System.Collections.Generic;

namespace HabitHero.Models;

public partial class Habit
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? LastCompletedDate { get; set; }

    public int CurrentStreak { get; set; }
}
