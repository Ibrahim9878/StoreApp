using StoreApp.Models.Entities.Abstracts;

namespace StoreApp.Models.Entities.Concretes
{
    public class Product : BaseEntitiy
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
