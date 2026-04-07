using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/slot")]
public class SLotController : ControllerBase
{
    [HttpPost("spin")]
    public IActionResult Spin()
    {
        return Ok("Spin endpoint workin");
    }
}