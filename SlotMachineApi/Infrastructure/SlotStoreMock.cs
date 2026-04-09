public class SlotStoreMock : ISlotStore
{
    private Slot _slot = new Slot
    {
        PlayerId = "4",
        LastStop = new[] {5, 20, 36, 18, 1}
    };

    public Task<Slot> Get()
     => Task.FromResult(_slot);

     public Task Set(Slot slot)
    {
        _slot = slot;
        return Task.CompletedTask;
    }
}