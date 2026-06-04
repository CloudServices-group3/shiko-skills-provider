using Microsoft.AspNetCore.Mvc;
using ShikoSkillsService.Application.Services;

namespace ShikoSkillsService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillsController : ControllerBase
{
    private readonly SkillService _skillService;

    public SkillsController(SkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetSkills(Guid userId)
    {
        if (userId == Guid.Empty)
            return BadRequest("UserId saknas.");

        var skills = await _skillService.GetUserSkillsAsync(userId);
        return Ok(skills);
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> AddSkill(Guid userId, [FromBody] string name)
    {
        if (userId == Guid.Empty)
            return BadRequest("UserId saknas.");

        var skill = await _skillService.AddSkillAsync(userId, name);
        return CreatedAtAction(nameof(GetSkills), new { userId }, skill);
    }

    [HttpPut("{userId}/{id}")]
    public async Task<IActionResult> UpdateSkill(Guid userId, int id, [FromBody] string name)
    {
        if (userId == Guid.Empty)
            return BadRequest("UserId saknas.");

        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Skill-namn saknas.");

        var updatedSkill = await _skillService.UpdateSkillAsync(userId, id, name);

        if (updatedSkill == null)
            return NotFound("Skill hittades inte.");

        return Ok(updatedSkill);
    }

    [HttpDelete("{userId}/{id}")]
    public async Task<IActionResult> DeleteSkill(Guid userId, int id)
    {
        if (userId == Guid.Empty)
            return BadRequest("UserId saknas.");

        await _skillService.DeleteSkillAsync(userId, id);
        return NoContent();
    }
}