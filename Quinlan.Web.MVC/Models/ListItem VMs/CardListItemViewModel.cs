using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quinlan.MVC.Models
{
    public class CardListItemViewModel
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string CardType { get; set; }
        public string Company { get; set; }

        public string CardNumber { get; set; }

        public string PersonName { get; set; }

        public string TeamName { get; set; }
        public string Grade { get; set; }
        public string GraderName { get; set; }

        public string HOF { get; set; }
        public string RC { get; set; }

        public string Attributes { get; set; }

        public string FormattedCost { get; set; }

        public string FormattedValue { get; set; }

        public int? SportId { get; set; }
        public int? LeagueId { get; set; }
        public int? PersonId { get; set; }
        public int? TeamId { get; set; }

    }
}
