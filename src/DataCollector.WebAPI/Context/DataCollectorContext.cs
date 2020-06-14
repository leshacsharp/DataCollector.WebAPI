using DataCollector.WebAPI.Models.Entities;
using DataCollector.WebAPI.Models.Interfaces;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;

namespace DataCollector.WebAPI.Context
{
    public class DataCollectorContext : IDbContext
    {
        private readonly IMongoDatabase _db;

        public DataCollectorContext(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            var client = new MongoClient(connectionString);
            var connection = new MongoUrlBuilder(connectionString);

            _db = client.GetDatabase(connection.DatabaseName);

           
        }

        static DataCollectorContext()
        {
            //todo: move this mapping to configure method
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return _db.GetCollection<User>("Users");
            }
        }
    }
}
