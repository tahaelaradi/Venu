﻿using MongoDbGenericRepository;

 namespace Venu.Events.API.Models
{
    public interface IRepository : IBaseMongoRepository<string>
    {
    }
}