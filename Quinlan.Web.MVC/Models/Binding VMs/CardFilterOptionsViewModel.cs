
using System.ComponentModel.DataAnnotations;

namespace Quinlan.MVC.Models
{
    public class CardFilterOptionsViewModel
    {
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Display(Name = "Year")]
        public int? Year { get; set; }

        [Display(Name = "HOFers")]
        public bool HOFFlag { get; set; }

        [Display(Name = "Heisman")]
        public bool HeismanFlag { get; set; }

        [Display(Name = "Notable")]
        public bool NotablePersonFlag { get; set; }

        [Display(Name = "Notable")]
        public bool NotableFlag { get; set; }

        [Display(Name = "RCs")]
        public bool RCFlag { get; set; }

        [Display(Name = "Graded")]
        public bool GradedFlag { get; set; }

        [Display(Name = "Autographs")]
        public bool AUFlag { get; set; }

        [Display(Name = "Relics")]
        public bool RelicFlag { get; set; }

        [Display(Name = "Vintage Only")]
        public bool VintageFlag { get; set; }

        [Display(Name = "Person")]
        public int PersonId { get; set; }

        [Display(Name = "Sport")]
        public int SportId { get; set; }

        [Display(Name = "League")]
        public int LeagueId { get; set; }

        [Display(Name = "Team")]
        public int TeamId { get; set; }

        [Display(Name = "College")]
        public int CollegeId { get; set; }

        [Display(Name = "Grading Service")]
        public int GraderId { get; set; }

        [Display(Name = "Grade")]
        public int GradeId { get; set; }

        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Min Value")]
        public decimal? MinValue { get; set; }

        [Display(Name = "Max Value")]
        public decimal? MaxValue { get; set; }
    }
}
