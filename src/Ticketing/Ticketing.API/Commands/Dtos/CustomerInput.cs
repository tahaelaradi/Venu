namespace Venu.Ticketing.API.Commands.Dtos
{
    public class CustomerInput
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public CustomerInput(int id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}