using System;

namespace Venu.Events.API.Exceptions
{
    public class SecurityException : Exception
    {
        public SecurityException(string message) : base(message)
        {
        }

        public static SecurityException NotFound(string entityType, string id)
        {
            if (entityType == null)
                throw new ArgumentNullException(nameof(entityType));
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return new SecurityException($"An entity [{entityType}] with ID: {id} was not found");
        }
    }
}