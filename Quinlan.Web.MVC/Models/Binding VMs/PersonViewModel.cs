
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quinlan.MVC.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Identifier")]
        [StringLength(100)]
        [Required]
        public string Identifier { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(100)]
        public string MiddleName { get; set; }

        [Display(Name = "Suffix")]
        [StringLength(100)]
        public string Suffix { get; set; }

        [Display(Name = "Is HOFer")]
        public bool HOFFlag { get; set; }

        [Display(Name = "Won Heisman")]
        public bool HeismanFlag { get; set; }

        [Display(Name = "Is Notable")]
        public bool NotableFlag { get; set; }

        [Display(Name = "College")]
        public int CollegeId { get; set; }

        [Display(Name = "Sport(s)")]
        public List<int> SportIds { get; set; }

    }
}
