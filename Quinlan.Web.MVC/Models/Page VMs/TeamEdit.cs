using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quinlan.Domain.Models;

namespace Quinlan.MVC.Models
{
    public class TeamEdit 
    {
        public string DisplayName { get; set; }
        public TeamViewModel TeamVM { get; set; } 
        public List<SelectListItem> Colleges { get; set; }
        public List<SelectListItem> Sports { get; set; }
        public List<SelectListItem> Leagues { get; set; }
    }
}
