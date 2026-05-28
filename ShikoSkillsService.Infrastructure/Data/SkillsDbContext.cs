using Microsoft.EntityFrameworkCore;
using ShikoSkillsService.Domain.Entities;

namespace ShikoSkillsService.Infrastructure.Data;

public class SkillsDbContext : DbContext
{
    public SkillsDbContext(DbContextOptions<SkillsDbContext> options) : base(options)
    {
    }

    public DbSet<Skill> Skills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("skills");

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.UserId).IsRequired();
            entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
        });
    }
}