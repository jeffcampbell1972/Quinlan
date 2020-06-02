using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Quinlan.MVC.Models
{
    public class FigurineIndex
    {
        public string DisplayName { get; set; }
        public FigurineFilterOptionsViewModel FilterOptions { get; set; }

        public string ShowHeismanFilter { get; set; }
        public string ShowPeopleFilters { get; set; }
        public List<SelectListItem> Years { get; set; }
        public List<SelectListItem> Teams { get; set; }
        public List<SelectListItem> People { get; set; }
        public List<SelectListItem> Leagues { get; set; }
        public List<SelectListItem> Colleges { get; set; }
        public SearchTotalsViewModel SearchTotalsVM { get; set; }
        public List<FigurineListItemViewModel> Figurines { get; set; }

    }
}
