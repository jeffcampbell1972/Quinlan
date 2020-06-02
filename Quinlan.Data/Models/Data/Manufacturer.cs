using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quinlan.Data.Models
{
    public class Manufacturer
    {
        [Key]
        [ForeignKey("Organization")]
        public int Id { get; set; }

        public Organization Organization { get; set; }
    }
}
