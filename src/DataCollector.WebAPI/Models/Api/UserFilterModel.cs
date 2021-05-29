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
        public string Book { get; set; }

        public string Film { get; set; }

        public string Game { get; set; }

        public string Music { get; set; }

        public string Hoobie { get; set; }
    }

    public class InterestFilteModel
    {
        public string TypeOfBook { get; set; }

        public string TypeOfFilm { get; set; }

        public string TypeOfGame { get; set; }

        public string TypeOfMusiс { get; set; }
    }
}
