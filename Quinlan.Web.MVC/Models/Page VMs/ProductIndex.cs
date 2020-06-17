using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Quinlan.Domain.Models;

namespace Quinlan.MVC.Models
{
    public class ProductIndex
    {
        public List<ProductListItemViewModel> Products { get; set; }

    }
}
