﻿using MongoDbGenericRepository;

 namespace Venu.Events.Domain
{
    public interface IRepository : IBaseMongoRepository<string>
    {
    }
}