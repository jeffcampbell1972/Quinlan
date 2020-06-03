
namespace Quinlan.Domain.Models
{
    public class MagazineSearchFilterOptions
    {
        public int? Year { get; set; }
        public bool HOFFlag { get; set; }
        public bool HeismanFlag { get; set; }
        public bool NotablePersonFlag { get; set; }
        public bool NotableFlag { get; set; }
        public int? PersonId { get; set; }
        public int? SportId { get; set; }
        public int? LeagueId { get; set; }
        public int? TeamId { get; set; }
        public int? CollegeId { get; set; }

    }
}
