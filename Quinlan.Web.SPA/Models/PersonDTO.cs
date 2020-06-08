using System.Collections.Generic;

namespace Quinlan.API.Models
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CardDTO> Cards { get; set; }
    }
}
