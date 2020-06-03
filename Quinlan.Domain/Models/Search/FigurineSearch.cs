using System.Collections.Generic;

namespace Quinlan.Domain.Models
{
    public class FigurineSearch
    {
        public FigurineSearchFilterOptions FilterOptions { get; set; }
        public List<Figurine> Figurines { get; set; }
        public int NumCollectibles { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalValue { get; set; }
    }
}
