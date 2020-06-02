using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quinlan.API.Models
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public string CompanyName { get; set; }
        public string CardNumber { get; set; }
        public string RC { get; set; }
        public string PersonName { get; set; }
        public string TeamName { get; set; }
    }
}
