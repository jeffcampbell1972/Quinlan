namespace Quinlan.Domain.Models
{
    public class SubTotal
    {
        public string Description { get; set; }
        public int NumItems { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalCost { get; set; }
    }
}
