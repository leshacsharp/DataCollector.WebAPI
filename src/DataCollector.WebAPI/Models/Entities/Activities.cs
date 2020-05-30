using System.Collections.Generic;

namespace DataCollector.WebAPI.Models.Entities
{
    public class Activities
    {
        public IEnumerable<string> Books { get; set; }

        public IEnumerable<string> Films { get; set; }

        public IEnumerable<string> Games { get; set; }

        public IEnumerable<string> Musics { get; set; }

        public IEnumerable<string> Hoobies { get; set; }
    }
}
