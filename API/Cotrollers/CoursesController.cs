using System.Threading.Tasks;
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
    public async Task<ActionResult<IEnumerable<CourseResponseDto>>> GetAllAsync()
    {
        var courses = await _courseService.GetAllAsync();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {

        var course = await _courseService.GetAsync(id);
        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(CourseRequestDto courseRequestDto)
    {
        CourseResponseDto result = await _courseService.AddAsync(courseRequestDto);
        return Created(string.Empty, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, CourseRequestDto courseRequestDto)
    {
        await _courseService.UpdateAsync(id, courseRequestDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        await _courseService.RemoveAsync(id);
        return Ok();
    }
}