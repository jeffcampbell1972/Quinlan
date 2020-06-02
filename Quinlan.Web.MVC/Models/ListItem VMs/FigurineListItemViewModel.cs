using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quinlan.MVC.Models
{
    public class FigurineListItemViewModel
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string CompanyName { get; set; }
        public string Number { get; set; }
        public string PersonName { get; set; }
        public string HOF { get; set; }
        public string SportName { get; set; }
        public string LeagueName { get; set; }
        public string TeamName { get; set; }
        public decimal Cost { get; set; }
        public decimal Value { get; set; }

        public int? PersonId { get; set; }
        public int? TeamId { get; set; }
    }
}
