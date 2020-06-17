using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quinlan.MVC.Models
{
    public class CardSearchViewModel
    {
        public CardFilterOptionsViewModel FilterOptions { get; set; }

        public string ShowHeismanFilter { get; set; }
        public string ShowPeopleFilters { get; set; }
        public List<SelectListItem> Years { get; set; }
        public List<SelectListItem> Teams { get; set; }
        public List<SelectListItem> People { get; set; }
        public List<SelectListItem> Leagues { get; set; }
        public List<SelectListItem> Colleges { get; set; }
        public List<SelectListItem> Graders { get; set; }
        public List<SelectListItem> Grades { get; set; }
    }
}
