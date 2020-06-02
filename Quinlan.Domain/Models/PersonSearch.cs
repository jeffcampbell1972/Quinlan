using System.Collections.Generic;

namespace Quinlan.Domain.Models
{
    public class PersonSearch
    {
        public PersonSearchFilterOptions PersonFilterOptions { get; set; }
        public List<Person> People { get; set; }
    }
}
