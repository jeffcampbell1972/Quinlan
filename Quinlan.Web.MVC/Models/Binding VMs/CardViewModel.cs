using System.ComponentModel.DataAnnotations;

namespace Quinlan.MVC.Models
{
    public class CardViewModel
    {
        public int Id { get; set; }
        public string Identifier { get; set; }

        [Display(Name = "Year")]
        public int Year { get; set; }

        [Display(Name = "Company/Set")]
        public string Company { get; set; }

        [Display(Name="Card #")]
        public int? CardNumber { get; set; }

        [Display(Name = "Person")]
        public string PersonName { get; set; }

        [Display(Name = "Team")]
        public string TeamName { get; set; }

        public string HOF { get; set; }
        public string RC { get; set; }
        public string SP { get; set; }
        public string Relic { get; set; }
        public string Autograph { get; set; }

        [Display(Name = "Q's Cost")]
        public decimal? Cost { get; set; }
        [Display(Name = "Q's Cost")]
        public string FormattedCost { get; set; }

        [Display(Name = "Value in DB")]
        public decimal? Value { get; set; }

        [Display(Name = "Value in DB")]
        public string FormattedValue { get; set; }

        public int? SportId { get; set; }
        public int? LeagueId { get; set; }
        public int? PersonId { get; set; }
        public int? TeamId { get; set; }
       
    }
}
