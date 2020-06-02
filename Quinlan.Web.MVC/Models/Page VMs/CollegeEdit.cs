using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quinlan.Domain.Models;

namespace Quinlan.MVC.Models
{
    public class CollegeEdit 
    {
        public string DisplayName { get; set; }
        public CollegeViewModel CollegeVM { get; set; } 
    }
}
