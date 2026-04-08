namespace SlotMachineApi.Models;

public record SpinResult(
    SlotDefinition.Symbol[][] Symbols,
    Prize[] Prizes,
    int TotalPayout
);