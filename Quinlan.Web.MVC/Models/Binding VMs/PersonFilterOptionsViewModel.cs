
namespace Quinlan.MVC.Models
{
    public class PersonFilterOptionsViewModel
    {
        public bool HOFFlag { get; set; }
        public bool HeismanFlag { get; set; }
        public bool NotableFlag { get; set; }
        
        public int? SportId { get; set; }
        public int? LeagueId { get; set; }
        public int? TeamId { get; set; }

    }
}
