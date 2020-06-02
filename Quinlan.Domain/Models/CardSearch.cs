using System.Collections.Generic;

namespace Quinlan.Domain.Models
{
    public class CardSearch
    {
        public CardSearchFilterOptions FilterOptions { get; set; }
        public List<Card> Cards { get; set; }
        public int NumCards { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalValue { get; set; }
    }
}
