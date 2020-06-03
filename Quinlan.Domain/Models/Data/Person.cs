using System;
using System.Collections.Generic;

namespace Quinlan.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public bool HOFFlag { get; set; }
        public bool HeismanFlag { get; set; }
        public bool NotableFlag { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }

        public College College { get; set; }
        public List<Sport> Sports { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}",
                FirstName ?? "",
                LastName);
        }
    }
}
