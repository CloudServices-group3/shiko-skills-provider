using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShikoSkillsService.Application.Services;
using System.Security.Claims;

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

    [HttpGet]
    public async Task<IActionResult> GetSkills()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Unauthorized();

        var skills = await _skillService.GetUserSkillsAsync(userId);
        return Ok(skills);
    }

    [HttpPost]
    public async Task<IActionResult> AddSkill([FromBody] string name)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Unauthorized();

        var skill = await _skillService.AddSkillAsync(userId, name);
        return CreatedAtAction(nameof(GetSkills), new { id = skill.Id }, skill);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSkill(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Unauthorized();

        await _skillService.DeleteSkillAsync(id, userId);
        return NoContent();
    }
}