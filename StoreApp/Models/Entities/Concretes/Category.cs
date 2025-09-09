using StoreApp.Models.Entities.Abstracts;

namespace StoreApp.Models.Entities.Concretes
{
    public class Category : BaseEntitiy
    {
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }

    }
}
