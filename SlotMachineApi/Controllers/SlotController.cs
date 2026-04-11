using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SlotMachineApi.Models;
using SlotMachineApi.Application;

[ApiController]
[Route("api/slot")]
public class SlotController : ControllerBase
{
    private readonly SpinSlotUseCase _spinUseCase;

    public SlotController(SpinSlotUseCase spinUseCase)
    {
        _spinUseCase = spinUseCase;
    }

    [HttpPost("spin")]
    public async Task<IActionResult> Spin([FromBody] SpinRequest request)
    {
        // Get id from JWT
        var playerId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub");

        if (playerId is null)
            return Unauthorized();

        // Use case
        var result = await _spinUseCase.Execute(playerId, request.Bet);

        // Response
        var response = new SpinResponse(
            Symbols: result.Symbols
                .Select(row => row.Select(x => x.ToString()).ToArray())
                .ToArray(),
            Prizes: result.Prizes,
            TotalPayout: result.TotalPayout
        );

        return Ok(response);
    }
}