using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

using Quinlan.Domain.Models;

namespace Quinlan.MVC.Models
{
    public class TeamIndex
    {
        public TeamFilterOptionsViewModel TeamFilterOptionsViewModel { get; set; }
        public List<TeamListItemViewModel> Teams { get; set; }
        public List<SelectListItem> Sports { get; set; }
        public List<SelectListItem> Leagues { get; set; }
    }
}
