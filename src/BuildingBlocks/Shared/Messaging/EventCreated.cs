namespace Venu.BuildingBlocks.Shared.Messaging
{
    public interface EventCreated
    {
        string Id { get; set; }
        string Name { get; }
    }
}
