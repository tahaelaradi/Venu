using GraphQL;
using GraphQL.Types;
using Venu.Events.GraphType.Mutations;
using Venu.Events.GraphType.Queries;

namespace Venu.Events.GraphType.AppSchema
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