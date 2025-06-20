using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/groups/{groupId}/students")]
public class StudentInGroupController : ControllerBase
{
    private readonly StudentInGroupService _studentInGroupService;

    public StudentInGroupController(StudentInGroupService studentInGroupService)
    {
        _studentInGroupService = studentInGroupService;
    }

    [HttpPost()]
    public async Task<IActionResult> AddAsync(int groupId, StudentRequestDto studentRequestDto)
    {
        StudentInGroupResponseDto result = await _studentInGroupService.AddStudent(groupId, studentRequestDto);
        return Created(string.Empty, result);
    }

    [HttpDelete("{studentId}")]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        await _studentInGroupService.RemoveAsync(id);
        return Ok();
    }
}