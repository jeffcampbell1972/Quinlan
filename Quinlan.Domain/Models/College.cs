
using System;

namespace Quinlan.Domain.Models
{
    public class College
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}",
                Name ?? "",
                Nickname);
        }
    }
}
