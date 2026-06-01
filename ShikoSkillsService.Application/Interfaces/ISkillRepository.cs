using ShikoSkillsService.Domain.Entities;

namespace ShikoSkillsService.Application.Interfaces;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetByUserIdAsync(Guid userId);
    Task<Skill> AddAsync(Skill skill);
    Task DeleteAsync(Guid userId, int id);
}