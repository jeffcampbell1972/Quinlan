using System.Collections.Generic;

namespace Quinlan.Domain.Models
{
    public class MagazineSearch
    {
        public MagazineSearchFilterOptions FilterOptions { get; set; }
        public List<Magazine> Magazines { get; set; }
        public int NumCollectibles { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalValue { get; set; }
    }
}
