
namespace Quinlan.Domain.Models
{
    public class CardSearchFilterOptions
    {
        public int? ProductId { get; set; }
        public int? Year { get; set; }
        public bool HOFFlag { get; set; }
        public bool HeismanFlag { get; set; }
        public bool NotablePersonFlag { get; set; }
        public bool NotableFlag { get; set; }
        public bool RCFlag { get; set; }
        public bool GradedFlag { get; set; }
        public bool RelicFlag { get; set; }
        public bool AutographedFlag { get; set; }
        public bool VintageFlag { get; set; }
        public int? PersonId { get; set; }
        public int? SportId { get; set; }
        public int? LeagueId { get; set; }
        public int? TeamId { get; set; }
        public int? CollegeId { get; set; }
        public int? GraderId { get; set; }
        public int? GradeId { get; set; }
        public int? ManufacturerId { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
    }
}
