using System.Runtime.Serialization;
using MediatR;

namespace Venu.Ticketing.API.Application.Commands
{
    [DataContract]
    public class CreateCustomerCommand : IRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public CreateCustomerCommand(int id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}