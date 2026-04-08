namespace SlotMachineApi.Models;

public record SpinResponse(
    string[][] Symbols,
    Prize[] Prizes,
    int TotalPayout
);