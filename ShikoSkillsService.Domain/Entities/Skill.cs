namespace ShikoSkillsService.Domain.Entities;

public class Skill
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}