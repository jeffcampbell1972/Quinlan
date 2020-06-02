using System.Collections.Generic;
using Quinlan.MVC.Models;

namespace Quinlan.MVC.Models
{
    public class TeamDetails
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string DisplayName { get; set; }
        public List<CardListItemViewModel> Cards { get; set; }
        public CardSearchViewModel FilterOptionsVM { get; set; }
        public SearchTotalsViewModel SearchTotalsVM { get; set; }     
    }
}
