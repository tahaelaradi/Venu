using MediatR;
using Venu.Ticketing.API.Commands.Dtos;

namespace Venu.Ticketing.API.Commands
{
    public class CreateCustomerCommand : IRequest
    {
        public CreateCustomerCommand(CustomerInput customerInput)
        {
            this.CustomerInput = customerInput;
        }
        
        public CustomerInput CustomerInput { get; set; }
    }
}