using ShikoSkillsService.Domain.Entities;

namespace ShikoSkillsService.Application.Interfaces;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetByUserIdAsync(Guid userId);
    Task<Skill> AddAsync(Skill skill);
    Task<Skill?> UpdateAsync(Guid userId, int id, string name);
    Task DeleteAsync(Guid userId, int id);
}