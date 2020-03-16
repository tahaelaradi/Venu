using System;
using System.Threading.Tasks;
using Venu.Events.API.Domain;
// using Event = Venu.Events.API.Domain.Event;
// using IRepository = Venu.Events.API.Domain.IRepository;

namespace Venu.Events.API.Setup
{
    public class MongoIndexInitializer
    {
        public static async Task Run(IRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            await repository.CreateAscendingIndexAsync<Event>(d => d.Id);
            await repository.CreateAscendingIndexAsync<Venue>(d => d.Id);
        }
    }
}