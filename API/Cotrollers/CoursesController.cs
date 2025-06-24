using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/course")]
public class CoursesController : ControllerBase
{
    private readonly CourseService _courseService;

    public CoursesController(CourseService courseService)
    {
        _courseService = courseService;
    }


    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<CourseResponseDto>>> GetAllAsync()
    {
        var courses = await _courseService.GetAllAsync();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetAsync(int id)
    {

        var course = await _courseService.GetAsync(id);
        return Ok(course);
    }

    [HttpPost]
    [Authorize(Roles = "TEACHER")]
    public async Task<IActionResult> AddAsync(CourseRequestDto courseRequestDto)
    {
        CourseResponseDto result = await _courseService.AddAsync(courseRequestDto);
        return Created(string.Empty, result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "TEACHER")]
    public async Task<IActionResult> UpdateAsync(int id, CourseRequestDto courseRequestDto)
    {
        await _courseService.UpdateAsync(id, courseRequestDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "TEACHER")]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        await _courseService.RemoveAsync(id);
        return Ok();
    }
}