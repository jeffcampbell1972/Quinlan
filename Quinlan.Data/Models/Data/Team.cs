
namespace Quinlan.Data.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string City { get; set; }
        public string Nickname { get; set; }
        public bool NotableFlag { get; set; }
        public int? SportId { get; set; }
        public int? LeagueId { get; set; }
        public int? CollegeId { get; set; }
        public int? ImportTeamId { get; set; }

        public Sport Sport { get; set; }
        public League League { get; set; }
        public College College { get; set; }
        public ImportTeam ImportTeam { get; set; }
    }
}
