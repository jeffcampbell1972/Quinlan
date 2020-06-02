
namespace Quinlan.Data.Models
{
    public class College
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int ImportCollegeId { get; set; }

        public ImportCollege ImportCollege { get; set; }
    }
}
