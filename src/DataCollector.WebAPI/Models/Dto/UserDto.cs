using MongoDB.Bson;

namespace DataCollector.WebAPI.Models.Dto
{
    public class UserDto
    {
        public ObjectId Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public int? Age { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public string Vk { get; set; }
    }
}
