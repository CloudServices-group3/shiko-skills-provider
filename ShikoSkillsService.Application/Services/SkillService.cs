using ShikoSkillsService.Application.Interfaces;
using ShikoSkillsService.Domain.Entities;

namespace ShikoSkillsService.Application.Services;

public class SkillService
{
    private readonly ISkillRepository _skillRepository;

    public SkillService(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<IEnumerable<Skill>> GetUserSkillsAsync(string userId)
    {
        return await _skillRepository.GetByUserIdAsync(userId);
    }

    public async Task<Skill> AddSkillAsync(string userId, string name)
    {
        var skill = new Skill
        {
            UserId = userId,
            Name = name
        };
        return await _skillRepository.AddAsync(skill);
    }

    public async Task DeleteSkillAsync(int id, string userId)
    {
        await _skillRepository.DeleteAsync(id, userId);
    }
}