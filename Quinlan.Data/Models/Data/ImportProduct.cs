
namespace Quinlan.Data.Models
{
    public class ImportProduct
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProductType { get; set; }
        public string ProductStatus { get; set; }
        public bool NotSure { get; set; }
    }
}
