using SlotMachineApi.Models;

public class SpinSlotUseCase
{
    private readonly IWallet _wallet;
    private readonly ISlotStore _slotStore;

    public async Task<SpinResult> Execute(string playerId, int bet)
    {
        // Check balance
        var balance = await _wallet.GetBalance(playerId);
        if (balance < bet)
            throw new InvalidOperationException("Insufficient balance");

        // Debit bet
        await _wallet.Debit(playerId, bet);

        // Slot state
        var slot = await _slotStore.Get();

        // Spin
        var (symbols, prizes) = slot.Spin(bet);

        // Calculate profit
        var totalPayout = prizes.Sum(p => p.Payout);

        // Accredit awards
        if (totalPayout > 0)
        {
            await _wallet.Credit(playerId, totalPayout);
        }

        // Save slot state
        await _slotStore.Set(slot);

        // Result
        return new SpinResult(
            symbols,
            prizes,
            totalPayout
        );
    }
}