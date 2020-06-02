using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quinlan.MVC.Models
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        [Display(Name = "City")]
        [StringLength(100)]
        [Required]
        public string City { get; set; }

        [Display(Name = "Name")]
        [StringLength(100)]
        [Required]
        public string Nickname { get; set; }

        [Display(Name = "Notable?")]
        public bool NotableFlag { get; set; }

        [Display(Name = "League")]
        public int LeagueId { get; set; }

        [Display(Name = "Sport")]
        public int SportId { get; set; }

        [Display(Name = "College")]
        public int CollegeId { get; set; }
    }
}
