using StoreApp.ViewModel.CategoyViewModels;

namespace StoreApp.ViewModel
{
    public class AddProductViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<CategoryWithProductViewModel>? Categories { get; set; }
    }
}
