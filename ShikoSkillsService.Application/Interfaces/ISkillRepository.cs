using ShikoSkillsService.Domain.Entities;

namespace ShikoSkillsService.Application.Interfaces;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetByUserIdAsync(string userId);
    Task<Skill> AddAsync(Skill skill);
    Task DeleteAsync(int id, string userId);
}