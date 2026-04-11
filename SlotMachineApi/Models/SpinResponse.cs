namespace SlotMachineApi.Models;

public record SpinResponse(
    string[][] Symbols,
    PrizeDTO[] Prizes,
    int TotalPayout
);