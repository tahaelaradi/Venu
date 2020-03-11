﻿using MongoDbGenericRepository;

 namespace Venu.Events.API.Domain
{
    public interface IRepository : IBaseMongoRepository<string>
    {
    }
}