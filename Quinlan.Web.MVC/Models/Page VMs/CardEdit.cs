using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quinlan.Domain.Models;

namespace Quinlan.MVC.Models
{
    public class CardEdit 
    {
        public string DisplayName { get; set; }
        public CardViewModel CardVM { get; set; } 
    }
}
