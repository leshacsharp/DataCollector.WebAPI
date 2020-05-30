using DataCollector.WebAPI.Models.Entities;
using MongoDB.Driver;

namespace DataCollector.WebAPI.Models.Interfaces
{
    public interface IDbContext
    {
        IMongoCollection<User> Users { get; }
    }
}
