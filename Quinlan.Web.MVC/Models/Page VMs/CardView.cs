using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Quinlan.Domain.Models;

namespace Quinlan.MVC.Models
{
    public class CardView
    {
        public string DisplayName { get; set; }
        public int Id { get; set; }
        public string Identifier { get; set; }

        [Display(Name = "Year")]
        public int Year { get; set; }

        [Display(Name = "Company/Set")]
        public string Company { get; set; }

        [Display(Name = "Card Type")]
        public string CardType { get; set; }

        [Display(Name = "Card #")]
        public int? CardNumber { get; set; }

        [Display(Name = "Person")]
        public string PersonName { get; set; }

        [Display(Name = "Sport")]
        public string SportName { get; set; }

        [Display(Name = "League")]
        public string LeagueName { get; set; }

        [Display(Name = "Team")]
        public string TeamName { get; set; }

        [Display(Name = "Grade")]
        public string Grade { get; set; }

        [Display(Name = "Attributes")]
        public List<string> Attributes { get; set; }

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


        [Display(Name = "Card Type")]
        public string ImportSubjectType { get; set; }

        [Display(Name = "Last Name")]
        public string ImportLastName { get; set; }

        [Display(Name = "First Name")]
        public string ImportFirstName { get; set; }

        [Display(Name = "Year")]
        public string ImportYear { get; set; }

        [Display(Name = "Company")]
        public string ImportCompany { get; set; }

        [Display(Name = "Card #")]
        public string ImportCardNumber { get; set; }

        [Display(Name = "Description")]
        public string ImportDescription { get; set; }

        [Display(Name = "Team")]
        public string ImportTeam { get; set; }

        [Display(Name = "Beckett Value")]
        public string ImportBeckett { get; set; }

        [Display(Name = "Cost")]
        public string ImportValue { get; set; }

        [Display(Name = "X1")]
        public string ImportX1 { get; set; }

        [Display(Name = "In Stock")]
        public string ImportInStock { get; set; }

        [Display(Name = "Sport")]
        public string ImportSport { get; set; }

        [Display(Name = "X2")]
        public string ImportX2 { get; set; }

        [Display(Name = "Grade")]
        public string ImportGrade { get; set; }

        [Display(Name = "X3")]
        public string ImportX3 { get; set; }

        [Display(Name = "Collectible Type")]
        public string ImportType { get; set; }

        [Display(Name = "League")]
        public string ImportLeague { get; set; }

        [Display(Name = "Is Notable")]
        public string ImportNotableFlag { get; set; }
    }
}
