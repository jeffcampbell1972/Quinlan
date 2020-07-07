using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Quinlan.Domain.Models;

namespace Quinlan.MVC.Models
{
    public class PersonDetails 
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string DisplayName { get; set; }
        public bool HasOwnerRights { get; set; }
        public List<CardListItemViewModel> Cards { get; set; }
        public CardSearchViewModel FilterOptionsVM { get; set; }
        public SearchTotalsViewModel SearchTotalsVM { get; set; }     
    }
}
