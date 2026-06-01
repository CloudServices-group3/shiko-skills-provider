using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShikoSkillsService.Application.Services;

namespace ShikoSkillsService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SkillsController : ControllerBase
{
    private readonly SkillService _skillService;

    public SkillsController(SkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpOptions]
    [AllowAnonymous]
    public IActionResult Options()
    {
        return Ok();
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetSkills(Guid userId)
    {
        if (userId == Guid.Empty)
            return Unauthorized();

        var skills = await _skillService.GetUserSkillsAsync(userId);
        return Ok(skills);
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> AddSkill(Guid userId, [FromBody] string name)
    {
        if (userId == Guid.Empty)
            return Unauthorized();

        var skill = await _skillService.AddSkillAsync(userId, name);
        return CreatedAtAction(nameof(GetSkills), new { userId = skill.Id }, skill);
    }

    [HttpDelete("{userId}/{id}")]
    public async Task<IActionResult> DeleteSkill(Guid userId, int id)
    {
        if (userId == Guid.Empty)
            return Unauthorized();

        await _skillService.DeleteSkillAsync(userId, id);
        return NoContent();
    }
}