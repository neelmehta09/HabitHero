using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HabitHero.Models;

public partial class HabitHeroDbContext : DbContext
{
    public HabitHeroDbContext()
    {
    }

    public HabitHeroDbContext(DbContextOptions<HabitHeroDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Habit> Habits { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Habit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Habits__3214EC07E8F9E5CE");

            entity.Property(e => e.LastCompletedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
