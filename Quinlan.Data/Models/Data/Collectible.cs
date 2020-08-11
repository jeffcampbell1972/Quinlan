using System;

namespace Quinlan.Data.Models
{
    public class Collectible
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public int OwnerId { get; set; }
        public int Year { get; set; }
        public int? CardNumber { get; set; }
        public string Condition { get; set; }
        public string GradingIdentifier { get; set; }
        public bool RCFlag { get; set; }
        public bool SPFlag { get; set; }
        public bool AUFlag { get; set; }
        public bool PatchFlag { get; set; }
        public bool GradedFlag { get; set; }
        public bool NotableFlag { get; set; }  // card is notable
        public decimal? Value { get; set; }
        public decimal? Cost { get; set; }
        
        public int? ImportCollectibleId { get; set; }
        public int? PersonId { get; set; }
        public int? TeamId { get; set; }
        public int? SportId { get; set; }
        public int? LeagueId { get; set; }
        public int? CardTypeId { get; set; }
        public int CollectibleTypeId { get; set; }
        public int CollectibleStatusId { get; set; }
        public int? SetId { get; set; }
        public int? GradeId { get; set; }
        public int? ProductId { get; set; }
        public int? ContainerId { get; set; }

        public Owner Owner { get; set; }
        public ImportCollectible ImportCollectible { get; set; }
        public Person Person { get; set; }
        public Sport Sport { get; set; }
        public League League { get; set; }
        public Team Team { get; set; }
        public CardType CardType { get; set; }
        public CollectibleType CollectibleType { get; set; }
        public CollectibleStatus CollectibleStatus { get; set; }
        public Set Set { get; set; }
        public Grade Grade { get; set; }
        public Product Product { get; set; }
        public Container Container { get; set; }
    }
}
