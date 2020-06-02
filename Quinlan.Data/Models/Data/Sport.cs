using System.Collections.Generic;

namespace Quinlan.Data.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }

        public IList<PersonSport> PersonSports { get; set; }
    }
}
