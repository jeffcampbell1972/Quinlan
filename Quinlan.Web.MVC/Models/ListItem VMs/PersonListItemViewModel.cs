using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quinlan.MVC.Models
{
    public class PersonListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CollegeId { get; set; }
        public string CollegeName { get; set; }
        public string SportNames { get; set; }
        public string HOFFlag { get; set; }
        public string HeismanFlag { get; set; }
        public string NotableFlag { get; set; }
    }
}
