using GraphQL.Types;

namespace Venu.Events.API.GraphType.Types
{
    public class EventInputType : InputObjectGraphType
    {
        public EventInputType()
        {
            Name = "EventInput";
            Field<StringGraphType>("name");
            // Field<StringGraphType>("summary");
            // Field<StringGraphType>("url");
            // Field<StringGraphType>("ticketsUrl");
            // Field<StringGraphType>("primaryOrganizerId");
            // Field<DateGraphType>("date");
            // Field<StringGraphType>("category");
            // Field<StringGraphType>("language");
            // Field<BooleanGraphType>("isFree");
        }
    }
}