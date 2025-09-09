using StoreApp.Models.Entities.Abstracts;

namespace StoreApp.Models.Entities.Concretes
{
    public class Order:BaseEntitiy
    {
        public int? Quantity { get; set; }
        public float? TotalPrice { get; set; }
        public List<Product>? Products { get; set; }

    }
}
