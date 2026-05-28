using Microsoft.EntityFrameworkCore;
using ShikoSkillsService.Application.Interfaces;
using ShikoSkillsService.Domain.Entities;
using ShikoSkillsService.Infrastructure.Data;

namespace ShikoSkillsService.Infrastructure.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly SkillsDbContext _context;

    public SkillRepository(SkillsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Skill>> GetByUserIdAsync(string userId)
    {
        return await _context.Skills
            .Where(s => s.UserId == userId)
            .ToListAsync();
    }

    public async Task<Skill> AddAsync(Skill skill)
    {
        _context.Skills.Add(skill);
        await _context.SaveChangesAsync();
        return skill;
    }

    public async Task DeleteAsync(int id, string userId)
    {
        var skill = await _context.Skills
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);

        if (skill != null)
        {
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
        }
    }
}