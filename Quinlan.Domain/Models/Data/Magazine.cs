using System;

namespace Quinlan.Domain.Models
{
    public class Magazine
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string PublisherName { get; set; }
        public string Description { get; set; }
        public string PersonName { get; set; }
        public string HOF { get; set; }
        public string SportName { get; set; }
        public string LeagueName { get; set; }
        public string TeamName { get; set; }
        public decimal Cost { get; set; }
        public decimal Value { get; set; }

        public int? PersonId { get; set; }
        public int? TeamId { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} #{2}",
                Year,
                PublisherName ,
                PersonName != null ? PersonName : "");
        }
    }
}
