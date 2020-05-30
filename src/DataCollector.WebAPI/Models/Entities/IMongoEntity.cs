using MongoDB.Bson;

namespace DataCollector.WebAPI.Models.Entities
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}
