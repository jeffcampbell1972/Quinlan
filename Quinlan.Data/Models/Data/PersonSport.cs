
namespace Quinlan.Data.Models
{
    public class PersonSport
    {
        public int PersonId { get; set; }
        public int SportId { get; set; }
        public Person Person { get; set; }
        public Sport Sport { get; set; }
    }
}
