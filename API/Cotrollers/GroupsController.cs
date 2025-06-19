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
    public async Task<IActionResult> GetAllAsyncs(string filterByGroup)
    {

        var course = await _groupsService.GetAllAsync(filterByGroup);
        return Ok(course);
    }


    [HttpPost]
    public async Task<IActionResult> AddAsync(GroupRequestDto groupRequestDto)
    {
        GroupResponseDto result = await _groupsService.AddAsync(groupRequestDto);
        return Created(string.Empty, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, GroupRequestDto groupRequestDto)
    {
        await _groupsService.UpdateAsync(id, groupRequestDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        await _groupsService.RemoveAsync(id);
        return Ok();
    }
}