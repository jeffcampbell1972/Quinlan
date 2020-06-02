using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Quinlan.Domain.Models;

namespace Quinlan.MVC.Models
{
    public class PersonIndex
    {
        public PersonFilterOptionsViewModel PersonFilterOptionsViewModel { get; set; }
        public List<PersonListItemViewModel> People { get; set; }
        public List<SelectListItem> Teams { get; set; }
        public List<SelectListItem> Sports { get; set; }
        public List<SelectListItem> Leagues { get; set; }
    }
}
