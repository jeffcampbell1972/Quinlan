using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quinlan.Data.Models
{
    public class Owner
    {
        [Key]
        [ForeignKey("Person")]
        public int Id { get; set; }
        public Person Person { get; set; }
    }
}
