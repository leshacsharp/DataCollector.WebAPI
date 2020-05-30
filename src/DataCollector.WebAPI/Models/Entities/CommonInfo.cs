using System;

namespace DataCollector.WebAPI.Models.Entities
{
    public class CommonInfo
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime? DateBirthday { get; set; }

        public int? Age => (DateTime.UtcNow - DateBirthday)?.Days / 365;

        public string Country { get; set; }

        public string City { get; set; }
    }
}
