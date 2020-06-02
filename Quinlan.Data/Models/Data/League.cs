
namespace Quinlan.Data.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public bool SearchDefault { get; set; }
        public int SortOrder { get; set; }
        public int SportId { get; set; }

        public Sport Sport { get; set; }
    }
}
