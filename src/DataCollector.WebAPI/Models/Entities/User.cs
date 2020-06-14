using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DataCollector.WebAPI.Models.Entities
{
    public class User : IMongoEntity
    {
        public ObjectId Id { get; set; }

        public CommonInfo CommonInfo { get; set; }

        public Contacts Contacts { get; set; }

        public IEnumerable<Education> Education { get; set; }

        public IEnumerable<Career> Career { get; set; }

        public LifePositions LifePositions { get; set; }

        public Activities Activities { get; set; }

        public Interests Interests { get; set; }
    }
}
