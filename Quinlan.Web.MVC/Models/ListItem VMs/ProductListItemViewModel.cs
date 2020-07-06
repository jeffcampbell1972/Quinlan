using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quinlan.MVC.Models
{
    public class ProductListItemViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string RC { get; set; }
        public string CardCount { get; set; }
        public string Price { get; set; }
    }
}
