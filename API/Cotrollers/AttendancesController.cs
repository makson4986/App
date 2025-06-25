using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class AttendancesController : ControllerBase
{
    private readonly AttendanceService _attendanceService;

    public AttendancesController(AttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }


    [HttpGet("lessons/{lessonId}/attendance")]
    public async Task<IActionResult> GetAsync(int lessonId)
    {
        var result = await _attendanceService.GetAllAsync(lessonId);
        return Ok(result);
    }

    [HttpPost("lessons/{lessonId}/attendance")]
    public async Task<IActionResult> MarkBulk(int lessonId, IEnumerable<AttendanceRequestDto> attendanceRequestDto)
    {
        var result = await _attendanceService.MarkBulk(lessonId, attendanceRequestDto);
        return Created(string.Empty, result);
    }

    [HttpPut("attendance/{attendancedId}")]
    public async Task<IActionResult> UpdateAsync(int attendancedId, AttendanceRequestDto attendanceRequestDto)
    {
        await _attendanceService.UpdateAsync(attendancedId, attendanceRequestDto);
        return Ok();
    }
}