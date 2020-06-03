using System;

namespace Quinlan.Domain.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string SetName { get; set; }
        public int? CardNumber { get; set; }
        public string Condition { get; set; }
        public Person Person { get; set; }
        public bool RCFlag { get; set; }
        public bool SPFlag { get; set; }
        public bool AUFlag { get; set; }
        public bool PatchFlag { get; set; }
        public bool GradedFlag { get; set; }
        public bool NotableFlag { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Value { get; set; }

        public Sport Sport { get; set; }
        public League League { get; set; }
        public CardType CardType { get; set; }
        public Team Team { get; set; }
        public ImportCard ImportCard { get; set; }
        public Grade Grade { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} #{2} {3} {4}",
                Year,
                SetName ,
                CardNumber ?? 0,
                Person != null ? Person.ToString() : "",
                RCFlag ? "RC" : "");
        }
    }
}
