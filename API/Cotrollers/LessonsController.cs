using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LessonsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetAll(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateNew()
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        return Ok();
    }
}