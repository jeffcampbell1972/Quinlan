using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Quinlan.MVC.Models
{
    public class Summary
    {
        public SubTotalViewModel DbTotals { get; set; }
        public List<SubTotalViewModel> CollectibleTypeSubTotals { get; set; }
        public List<SubTotalViewModel> BaseballCardSubTotals { get; set; }
        public List<SubTotalViewModel> BasketballCardSubTotals { get; set; }
        public List<SubTotalViewModel> FootballCardSubTotals { get; set; }
        public List<SubTotalViewModel> HockeyCardSubTotals { get; set; }
    }
}
