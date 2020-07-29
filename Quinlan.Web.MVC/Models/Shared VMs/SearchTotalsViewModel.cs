using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quinlan.MVC.Models
{
    public class SearchTotalsViewModel
    {
        public int NumCollectibles { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalValue { get; set; }
        public bool ShowTotalCost { get; set; }
    }
}
