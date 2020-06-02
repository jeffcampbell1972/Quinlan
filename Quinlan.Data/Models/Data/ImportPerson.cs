
namespace Quinlan.Data.Models
{
    public class ImportPerson
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
        public string CollegeIdentifier { get; set; }
    }
}
