using System;
using System.Threading.Tasks;
using Venu.Events.Domain;

namespace Venu.Events.API.Setup
{
    public class MongoIndexInitializer
    {
        public static async Task Run(IRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            await repository.CreateAscendingIndexAsync<Event>(d => d.Name);
        }
    }
}