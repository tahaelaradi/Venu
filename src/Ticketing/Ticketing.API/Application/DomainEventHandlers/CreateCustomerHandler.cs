using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using Venu.Ticketing.API.Application.Commands;
using Venu.Ticketing.Domain.AggregatesModel.CustomerAggregate;
using Venu.Ticketing.Infrastructure.Repositories;

namespace Venu.Ticketing.API.Application.DomainEventHandlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly CustomerRepository _customerRepository;
        
        public CreateCustomerHandler(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.CustomerInput.Id, request.CustomerInput.Username);
            Log.Information($"Creating Customer: {customer.Username}");
            
            await _customerRepository.Add(customer);
            return Unit.Value;
        }
    }
}