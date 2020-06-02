using System.Collections.Generic;

namespace Quinlan.Domain.Models
{
    public class DataSummary
    {
        public DataSummary()
        {
            CollectibleTypeSubTotals = new List<SubTotal>();
            BaseballCardSubTotals = new List<SubTotal>();
            BasketballCardSubTotals = new List<SubTotal>();
            FootballCardSubTotals = new List<SubTotal>();
            HockeyCardSubTotals = new List<SubTotal>();
        }
        public SubTotal DbTotals { get; set; }
        public List<SubTotal> CollectibleTypeSubTotals { get; set; }
        public List<SubTotal> BaseballCardSubTotals { get; set; }
        public List<SubTotal> BasketballCardSubTotals { get; set; }
        public List<SubTotal> FootballCardSubTotals { get; set; }
        public List<SubTotal> HockeyCardSubTotals { get; set; }
    }
}
