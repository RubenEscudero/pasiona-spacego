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

    public (SlotDefinition.Symbol[][] Symbols, Prize[] Prizes) Spin(int bet)
    {
        //Validate
        ValidateBet(bet);

        //Generate stops
        var newStops = GenerateNewStops();

        //Return visibleSymbols
        var visibleSymbols = BuildVisibleMatrix(newStops);

        //Gives a prizes
        var prizes = EvaluatePaylines(visibleSymbols, bet);

        LastStop =  newStops;

        return (visibleSymbols, prizes);
    }

    /// <summary>
    /// Validate of the bet amount
    /// </summary>
    /// <param name="bet"></param>
    private static void ValidateBet(int bet)
    {
        if (!SlotDefinition.AvailableBets.Contains(bet))
        {
            throw new ArgumentException($"Invalid bet value: {bet}");
        }
    }

    /// <summary>
    /// Generates new stops when playing a spin
    /// </summary>
    /// <returns></returns>
    private int[] GenerateNewStops()
    {
        var random = new Random();
        var newStops = new int[5];

        var strips = new[]
        {
            SlotDefinition.Reel0Strip,
            SlotDefinition.Reel1Strip,
            SlotDefinition.Reel2Strip,
            SlotDefinition.Reel3Strip,
            SlotDefinition.Reel4Strip
        };

        for (int i = 0; i < strips.Length; i++)
        {
            var offset = random.Next(1, strips[i].Length);
            newStops[i] = (LastStop[i] + offset) % strips[i].Length;
        }

        return newStops;
    }

    /// <summary>
    /// Based on the stops, it returns the symbols
    /// </summary>
    /// <param name="newStops"></param>
    /// <returns></returns>
    private static SlotDefinition.Symbol[][] BuildVisibleMatrix(int[] newStops)
    {
        const int rows = 4;
        const int reels = 5;

        var strips = new[]
        {
            SlotDefinition.Reel0Strip,
            SlotDefinition.Reel1Strip,
            SlotDefinition.Reel2Strip,
            SlotDefinition.Reel3Strip,
            SlotDefinition.Reel4Strip
        };

        var matrix = new SlotDefinition.Symbol[rows][];

        for (int row = 0; row < rows; row++)
        {
            matrix[row] = new SlotDefinition.Symbol[reels];

            for (int reel = 0; reel < reels; reel++)
            {
                var strip = strips[reel];
                var index = (newStops[reel] + row) % strip.Length;

                matrix[row][reel] = strip[index];
            }
        }

        return matrix;
    }

    /// <summary>
    /// Return the prize based on the symbols
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="bet"></param>
    /// <returns></returns>

    private Prize[] EvaluatePaylines(SlotDefinition.Symbol[][] matrix, int bet)
    {
        var prizes = new List<Prize>();

        foreach (var line in SlotDefinition.Lines)
        {
            var symbols = line.GridPositions
                .Select(p => matrix[p.Row][p.Reel])
                .ToArray();

            var firstSymbol = symbols[0];
            var count = 1;

            for (int i = 1; i < symbols.Length; i++)
            {
                if (symbols[i] == firstSymbol)
                   break;

                count++;
            }

            if (count < 3)
                continue;
            
            var paytable = SlotDefinition.Paytable[firstSymbol];
            var payoutMultiplier = paytable[count - 1];

            if (payoutMultiplier <= 0)
                continue;

            prizes.Add(new Prize(
                line,
                count,
                payoutMultiplier * bet
            ));
        }

        return prizes.ToArray();
    }
}