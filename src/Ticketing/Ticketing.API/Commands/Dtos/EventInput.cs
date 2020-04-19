namespace Venu.Ticketing.API.Commands.Dtos
{
    public class EventInput
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public EventInput(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}