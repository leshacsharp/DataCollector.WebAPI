using DataCollector.WebAPI.Models.Entities;

namespace DataCollector.WebAPI.Models.Api
{
    public class UserFilterModel
    {
        public UserFilterModel()
        {
            CommonInfo = new CommonInfoFilteModel();
            Contacts = new Contacts();
            Education = new Education();
            Career = new Career();
            LifePositions = new LifePositions();
            Activity = new ActivityFilteModel();
            Interest = new InterestFilteModel();
        }

        public CommonInfoFilteModel CommonInfo { get; set; }

        public Contacts Contacts { get; set; }

        public Education Education { get; set; }

        public Career Career { get; set; }

        public LifePositions LifePositions { get; set; }

        public ActivityFilteModel Activity { get; set; }

        public InterestFilteModel Interest { get; set; }

        public int? From { get; set; }

        public int? Count { get; set; }
    }

    public class CommonInfoFilteModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public int FromAge { get; set; }

        public int ToAge { get; set; }

        public bool WithoutAge { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }

    public class ActivityFilteModel
    {
        public string Books { get; set; }

        public string Films { get; set; }

        public string Games { get; set; }

        public string Musics { get; set; }

        public string Hoobies { get; set; }
    }

    public class InterestFilteModel
    {
        public string TypesOfBooks { get; set; }

        public string TypesOfFilms { get; set; }

        public string TypesOfGames { get; set; }

        public string TypesOfMusic { get; set; }
    }
}
