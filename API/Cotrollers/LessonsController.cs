using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/lessons")]
public class LessonsController : ControllerBase
{
    private readonly LessonsService _lessonsService;


    public LessonsController(LessonsService lessonsService)
    {
        _lessonsService = lessonsService;
    }


    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<LessonResponseDto>>> GetByFilter(int? courseId = null, int? groupId = null)
    {
        var lessons = await _lessonsService.GetByFilter(courseId, groupId);
        return Ok(lessons);
    }


    [HttpPost]
    [Authorize(Roles = "TEACHER")]
    public async Task<IActionResult> CreateNew(LessonRequestDto lessonRequestDto)
    {
        var result = await _lessonsService.AddAsync(lessonRequestDto);
        return Created(string.Empty, result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "TEACHER")]
    public async Task<IActionResult> Update(int id, LessonRequestDto lessonRequestDto)
    {
        await _lessonsService.UpdateAsync(id, lessonRequestDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "TEACHER")]
    public async Task<IActionResult> Delete(int id)
    {
        await _lessonsService.RemoveAsync(id);
        return Ok();
    }
}