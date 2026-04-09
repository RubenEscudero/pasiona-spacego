using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SlotMachineApi.Services;
using SlotMachineApi.Models;
using LoginRequest = SlotMachineApi.Models.LoginRequest;

namespace SlotMachineApi.Controller;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenService _jwt;

    public AuthController(JwtTokenService jwt)
    {
        _jwt = jwt;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.PlayerId))
            return BadRequest("PlayerId is required");

        var token = _jwt.GenerateToken(request.PlayerId);

        return Ok(new { token });
    }
}