
namespace Quinlan.Domain.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public int SportId { get; set; }
        public bool SearchDefault { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
