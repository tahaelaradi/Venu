using GraphQL;
using GraphQL.Types;
using Venu.Events.API.GraphType.Mutations;
using Venu.Events.API.GraphType.Queries;

namespace Venu.Events.API.GraphType.AppSchema
{
    public class EventsSchema : Schema
    {
        public EventsSchema(EventsQuery query, EventsMutation mutation, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            DependencyResolver = resolver;
        }
    }
}