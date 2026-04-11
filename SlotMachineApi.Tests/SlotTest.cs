using SlotMachineApi.Domain;

namespace SlotMachineApi.Tests;

public class UnitTest1
{
    [Fact]
    public void Spin_ShouldReturnSymbolsAndPrizes()
    {
        //Arrange
        var slot = new Slot
        {
            PlayerId = "Test",
            LastStop = new [] { 0, 0, 0, 0, 0 }
        };

        //Act
        var (symbols, prizes) = slot.Spin(1);

        //Assert
        Assert.NotNull(symbols);
        Assert.Equal(4, symbols.Length);
        Assert.All(symbols, row => Assert.Equal(5, row.Length));

        Assert.NotNull(prizes);
        Assert.Equal(5, slot.LastStop.Length);
    }

    [Fact]
    public void Spin_ShouldThrow_WhenBetIsInvalid()
    {
        var slot = new Slot
        {
            PlayerId = "test",
            LastStop = new [] { 0, 0, 0, 0, 0 }
        };

        Assert.Throws<ArgumentException>(() => slot.Spin(999));
    }
}
