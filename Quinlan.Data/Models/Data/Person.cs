using System.Collections.Generic;

namespace Quinlan.Data.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public bool? HOFFlag { get; set; }
        public bool? HeismanFlag { get; set; }
        public bool? NotableFlag { get; set; }
        public int? CollegeId { get; set; }
        public int? ImportPersonId { get; set; }

        public College College { get; set; }
        public ImportPerson ImportPerson { get; set; }
        public IList<PersonSport> PersonSports { get; set; }
    }
}
