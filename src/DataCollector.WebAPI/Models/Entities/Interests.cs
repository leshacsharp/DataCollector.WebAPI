using System.Collections.Generic;

namespace DataCollector.WebAPI.Models.Entities
{
    public class Interests
    {
        public IEnumerable<string> TypesOfBooks { get; set; }

        public IEnumerable<string> TypesOfFilms { get; set; }

        public IEnumerable<string> TypesOfGames { get; set; }

        public IEnumerable<string> TypesOfMusic { get; set; }
    }
}
