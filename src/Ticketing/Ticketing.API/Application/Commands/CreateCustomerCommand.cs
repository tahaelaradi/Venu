using MediatR;

namespace Venu.Ticketing.API.Application.Commands
{
    public class CreateCustomerCommand : IRequest
    {
        public CreateCustomerCommand(CustomerInput customerInput)
        {
            this.CustomerInput = customerInput;
        }
        
        public CustomerInput CustomerInput { get; set; }
    }
    
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