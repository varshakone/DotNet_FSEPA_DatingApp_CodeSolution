using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DatingApp.DataLayer
{
    public class MongoDBContext : IMongoDBContext
    {
        private IMongoDatabase _mongoDB;
        private IMongoClient _mongoClient;
        public MongoDBContext(IOptions<MongoSettings> options)
        {
            _mongoClient = new MongoClient(options.Value.Connection);
            _mongoDB = _mongoClient.GetDatabase(options.Value.DatabaseName);
        }
        public IMongoCollection<TEntity> GetCollection<TEntity>(string name)
        {
            return _mongoDB.GetCollection<TEntity>(name);
        }
    }
}
