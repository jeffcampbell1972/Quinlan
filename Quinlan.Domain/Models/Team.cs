
using System;

namespace Quinlan.Domain.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string City { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public bool NotableFlag { get; set; }
        public League League { get; set; }
        public Sport Sport { get; set; }
        public College College { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}",
                City ?? "",
                Nickname);
        }
    }
}
