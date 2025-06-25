using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/groups")]
public class GroupsController : ControllerBase
{
    private readonly GroupsService _groupsService;

    public GroupsController(GroupsService groupsService)
    {
        _groupsService = groupsService;
    }


    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllAsyncs(string filterByCourse)
    {
        var course = await _groupsService.GetAllAsync(filterByCourse);
        return Ok(course);
    }


    [HttpPost]
    [Authorize(Roles = "TEACHER")]
    public async Task<IActionResult> AddAsync(GroupRequestDto groupRequestDto)
    {
        GroupResponseDto result = await _groupsService.AddAsync(groupRequestDto);
        return Created(string.Empty, result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "TEACHER")]
    public async Task<IActionResult> UpdateAsync(int id, GroupRequestDto groupRequestDto)
    {
        await _groupsService.UpdateAsync(id, groupRequestDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "TEACHER")]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        await _groupsService.RemoveAsync(id);
        return Ok();
    }
}