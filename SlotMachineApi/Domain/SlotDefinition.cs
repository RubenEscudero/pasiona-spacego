/// <summary>
/// Represents a fixed position on the slot machine grid,
/// defined by reel index and row index.
/// </summary>
/// <param name="Reel">Index of the reel (column)</param>
/// <param name="Row">Index of the row (horizontal position)</param>
public record struct GridPosition(int Reel, int Row);


/// <summary>
/// Represents a payline definition with an identifier and
/// the ordered grid positions that form the line.
/// </summary>
/// <param name="Id">Unique identifier of the line</param>
/// <param name="GridPositions">Ordered positions across the reels</param>
public sealed record Line(int Id, GridPosition[] GridPositions);


/// <summary>
/// Contains the full static definition of the slot machine:
/// reels, symbols, paylines, available bets, and paytable.
/// </summary>
public static class SlotDefinition
{
    /// <summary>
    /// Enumeration of all possible symbols that can appear in the reels.
    /// </summary>
    public enum Symbol
    {
        AA,
        KK,
        QQ,
        JJ,
        P1,
        P2,
        P3,
    }


    /// <summary>
    /// Defines all available betting values.
    /// </summary>
    public static readonly int[] AvailableBets = [1, 2, 5, 10, 15, 20, 50];


    /// <summary>
    /// Reel 0 strip configuration.
    /// </summary>
    public static readonly Symbol[] Reel0Strip =
    [
        Symbol.QQ,
        Symbol.P2,
        Symbol.QQ,
        Symbol.AA,
        Symbol.P3,
        Symbol.P2,
        Symbol.KK,
        Symbol.JJ,
        Symbol.P3,
        Symbol.P1,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.AA,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.AA,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.AA,
        Symbol.JJ,
        Symbol.AA,
        Symbol.KK,
        Symbol.AA,
        Symbol.QQ,
        Symbol.KK,
        Symbol.P3,
        Symbol.P2,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.P2,
        Symbol.P3,
        Symbol.P2,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.P3,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.P3,
        Symbol.P1,
        Symbol.QQ,
        Symbol.AA,
        Symbol.KK,
        Symbol.KK,
        Symbol.P2,
        Symbol.AA,
        Symbol.KK,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.P3,
        Symbol.P2,
        Symbol.QQ,
        Symbol.KK,
        Symbol.AA,
        Symbol.KK,
        Symbol.KK,
        Symbol.P3,
        Symbol.KK,
        Symbol.AA,
        Symbol.JJ,
        Symbol.JJ,
    ];

    /// <summary>
    /// Reel 1 strip configuration.
    /// </summary>
    public static readonly Symbol[] Reel1Strip =
    [
        Symbol.P2,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.KK,
        Symbol.KK,
        Symbol.QQ,
        Symbol.AA,
        Symbol.P3,
        Symbol.P3,
        Symbol.KK,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.P2,
        Symbol.KK,
        Symbol.AA,
        Symbol.QQ,
        Symbol.KK,
        Symbol.AA,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.AA,
        Symbol.JJ,
        Symbol.AA,
        Symbol.KK,
        Symbol.JJ,
        Symbol.P3,
        Symbol.KK,
        Symbol.AA,
        Symbol.P1,
        Symbol.QQ,
        Symbol.P3,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.P2,
        Symbol.JJ,
        Symbol.AA,
        Symbol.JJ,
        Symbol.P1,
        Symbol.AA,
        Symbol.KK,
        Symbol.JJ,
        Symbol.P3,
        Symbol.AA,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.KK,
        Symbol.QQ,
        Symbol.KK,
        Symbol.KK,
        Symbol.JJ,
        Symbol.AA,
        Symbol.KK,
        Symbol.P1,
        Symbol.JJ,
        Symbol.AA,
        Symbol.QQ,
        Symbol.KK,
        Symbol.JJ,
    ];

    /// <summary>
    /// Reel 2 strip configuration.
    /// </summary>
    public static readonly Symbol[] Reel2Strip =
    [
        Symbol.AA,
        Symbol.QQ,
        Symbol.P1,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.P3,
        Symbol.JJ,
        Symbol.AA,
        Symbol.KK,
        Symbol.KK,
        Symbol.QQ,
        Symbol.P1,
        Symbol.JJ,
        Symbol.AA,
        Symbol.QQ,
        Symbol.P3,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.AA,
        Symbol.AA,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.P3,
        Symbol.AA,
        Symbol.AA,
        Symbol.QQ,
        Symbol.P2,
        Symbol.P1,
        Symbol.JJ,
        Symbol.KK,
        Symbol.KK,
        Symbol.JJ,
        Symbol.AA,
        Symbol.P2,
        Symbol.P3,
        Symbol.AA,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.KK,
        Symbol.QQ,
        Symbol.AA,
        Symbol.JJ,
        Symbol.P2,
        Symbol.QQ,
        Symbol.AA,
        Symbol.AA,
        Symbol.KK,
        Symbol.JJ,
        Symbol.KK,
        Symbol.AA,
        Symbol.JJ,
        Symbol.KK,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.KK,
        Symbol.JJ,
        Symbol.AA,
        Symbol.KK,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.AA,
        Symbol.KK,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.AA,
    ];

    /// <summary>
    /// Reel 3 strip configuration.
    /// </summary>
    public static readonly Symbol[] Reel3Strip =
    [
        Symbol.KK,
        Symbol.QQ,
        Symbol.P2,
        Symbol.KK,
        Symbol.AA,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.AA,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.AA,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.AA,
        Symbol.JJ,
        Symbol.AA,
        Symbol.KK,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.P2,
        Symbol.QQ,
        Symbol.P1,
        Symbol.KK,
        Symbol.JJ,
        Symbol.P3,
        Symbol.QQ,
        Symbol.KK,
        Symbol.QQ,
        Symbol.KK,
        Symbol.JJ,
        Symbol.AA,
        Symbol.KK,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.P3,
        Symbol.AA,
        Symbol.JJ,
        Symbol.AA,
        Symbol.AA,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.P2,
        Symbol.AA,
        Symbol.P3,
        Symbol.AA,
        Symbol.AA,
        Symbol.JJ,
        Symbol.KK,
        Symbol.JJ,
        Symbol.P3,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.P3,
        Symbol.KK,
        Symbol.KK,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.AA,
        Symbol.KK,
        Symbol.KK,
        Symbol.KK,
        Symbol.KK,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.AA,
        Symbol.KK,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.P1,
    ];

    /// <summary>
    /// Reel 4 strip configuration.
    /// </summary>
    public static readonly Symbol[] Reel4Strip =
    [
        Symbol.QQ,
        Symbol.KK,
        Symbol.KK,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.AA,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.KK,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.AA,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.AA,
        Symbol.JJ,
        Symbol.AA,
        Symbol.KK,
        Symbol.AA,
        Symbol.QQ,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.QQ,
        Symbol.P2,
        Symbol.KK,
        Symbol.AA,
        Symbol.KK,
        Symbol.P2,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.AA,
        Symbol.P1,
        Symbol.KK,
        Symbol.AA,
        Symbol.P3,
        Symbol.P2,
        Symbol.AA,
        Symbol.JJ,
        Symbol.P3,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.AA,
        Symbol.QQ,
        Symbol.KK,
        Symbol.P3,
        Symbol.KK,
        Symbol.JJ,
        Symbol.AA,
        Symbol.JJ,
        Symbol.KK,
        Symbol.AA,
        Symbol.AA,
        Symbol.JJ,
        Symbol.AA,
        Symbol.KK,
        Symbol.P1,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.JJ,
        Symbol.AA,
        Symbol.KK,
        Symbol.QQ,
        Symbol.QQ,
        Symbol.P3,
    ];


    /// <summary>
    /// List of all paylines evaluated by the slot machine.
    /// Each line is represented as an ordered set of grid positions.
    /// </summary>
    public static readonly Line[] Lines =
    [
        new Line(0, [.. new[] { 1, 1, 1, 1, 1 }.Select((x, i) => new GridPosition(i, x))]),
        new Line(1, [.. new[] { 0, 0, 0, 0, 0 }.Select((x, i) => new GridPosition(i, x))]),
        new Line(2, [.. new[] { 2, 2, 2, 2, 2 }.Select((x, i) => new GridPosition(i, x))]),
        new Line(3, [.. new[] { 3, 3, 3, 3, 3 }.Select((x, i) => new GridPosition(i, x))]),
        new Line(4, [.. new[] { 1, 2, 3, 2, 1 }.Select((x, i) => new GridPosition(i, x))]),
        new Line(5, [.. new[] { 2, 1, 0, 1, 2 }.Select((x, i) => new GridPosition(i, x))]),
        new Line(6, [.. new[] { 1, 0, 0, 0, 1 }.Select((x, i) => new GridPosition(i, x))]),
        new Line(7, [.. new[] { 2, 3, 3, 3, 2 }.Select((x, i) => new GridPosition(i, x))]),
        new Line(8, [.. new[] { 3, 2, 1, 0, 0 }.Select((x, i) => new GridPosition(i, x))]),
        new Line(9, [.. new[] { 0, 1, 2, 3, 3 }.Select((x, i) => new GridPosition(i, x))]),
    ];


    /// <summary>
    /// Paytable indexed by symbol,
    /// the position within the array indicates the number of consecutive symbols,
    /// and the value indicates the multiplier to be used to calculate the payout.
    /// </summary>
    public static readonly Dictionary<Symbol, int[]> Paytable = new()
    {
        [Symbol.AA] = [0, 0, 5, 25, 100],
        [Symbol.KK] = [0, 0, 5, 25, 100],
        [Symbol.QQ] = [0, 0, 5, 25, 100],
        [Symbol.JJ] = [0, 0, 5, 25, 100],
        [Symbol.P1] = [0, 0, 25, 100, 400],
        [Symbol.P2] = [0, 0, 20, 75, 250],
        [Symbol.P3] = [0, 0, 15, 50, 200],
    };
}


/// <summary>
/// Abstraction of an external service to manage a user's wallet.
/// </summary>
public interface IWallet
{
    /// <summary>
    /// Gets the current wallet balance for a specific player.
    /// </summary>
    public Task<long> GetBalance(string playerId);

    /// <summary>
    /// Credits the player's wallet with a given amount.
    /// </summary>
    public Task<long> Credit(string playerId, long amount);

    /// <summary>
    /// Debits the player's wallet by a given amount.
    /// </summary>
    public Task<long> Debit(string playerId, long amount);
}


/// <summary>
/// Represents a slot machine for a specific player.
/// </summary>
public class Slot
{
    /// <summary>
    /// The unique identifier of the player associated with this slot.
    /// </summary>
    public required string PlayerId { get; init; }

    /// <summary>
    /// Stores the last stop index for each reel.
    /// </summary>
    public required int[] LastStop { get; set; }

    ///public <Symbol[][], Prize[]> Spin(int bet)
    ///{
        ///throw new NotImplementedException();
    ///}
}


/// <summary>
/// Represents a payout result for a specific line, including
/// symbol count and payout amount.
/// </summary>
/// <param name="Line">The winning line</param>
/// <param name="N">Number of consecutive matching symbols</param>
/// <param name="Payout">Total payout for this result</param>
public record Prize(Line Line, int N,int Payout);


/// <summary>
/// Abstraction for reading and updating the persistent slot state.
/// </summary>
public interface ISlotStore
{

    /// <summary>
    /// Retrieves the current slot state.
    /// </summary>
    Task<Slot> Get();

    /// <summary>
    /// Persists an updated slot state.
    /// </summary>
    Task Set(Slot slot);
}