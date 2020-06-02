using System.Collections.Generic;

namespace Quinlan.Domain.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public List<League> Leagues { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
