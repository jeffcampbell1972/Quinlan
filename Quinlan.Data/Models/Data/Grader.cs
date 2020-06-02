using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quinlan.Data.Models
{
    public class Grader
    {
        [Key]
        [ForeignKey("Organization")]
        public int Id { get; set; }

        public Organization Organization { get; set; }
    }
}
