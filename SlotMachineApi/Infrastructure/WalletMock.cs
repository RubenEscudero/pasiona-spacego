public class WalletMock : IWallet
{
    private long _balance = 500;

    public Task<long> GetBalance(string playerId)
     => Task.FromResult(_balance);

    public Task<long> Credit(string playerId, long amount)
    {
        _balance += amount;
        return Task.FromResult(_balance);
    }

    public Task<long> Debit(string playerId, long amount)
    {
        _balance -= amount;
        return Task.FromResult(_balance);
    }
}