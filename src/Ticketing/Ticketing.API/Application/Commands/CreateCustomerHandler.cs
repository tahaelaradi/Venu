using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using Venu.Ticketing.Domain.AggregatesModel.CustomerAggregate;
using Venu.Ticketing.Infrastructure.Repositories;

namespace Venu.Ticketing.API.Application.Commands
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly CustomerRepository _customerRepository;
        
        public CreateCustomerHandler(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<Unit> Handle(CreateCustomerCommand message, CancellationToken cancellationToken)
        {
            Log.Information($"Creating Customer: {message.Username}");
            var customer = new Customer(message.Id, message.Username);
            
            await _customerRepository.Add(customer);
            return Unit.Value;
        }
    }
}