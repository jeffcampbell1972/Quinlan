using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quinlan.MVC.Models
{
    public class TeamListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SportName { get; set; }
        public string LeagueName { get; set; }
        public int CollegeId { get; set; }
        public string CollegeName { get; set; }
    }
}
