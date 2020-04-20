namespace Venu.BuildingBlocks.Shared.Messaging
{
    public interface UserCreated
    {
        int Id { get; set; }
        string Username { get; }
    }
}