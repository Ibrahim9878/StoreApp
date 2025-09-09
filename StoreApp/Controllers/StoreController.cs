using Microsoft.AspNetCore.Mvc;
using StoreApp.Context;
using StoreApp.Models.Entities.Concretes;
using StoreApp.ViewModel;

namespace StoreApp.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreAppDbContext _dbContext;
        

        public StoreController(StoreAppDbContext context)
        {
            _dbContext = context;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _dbContext.Products.ToList();
            var prViewModel = products.Select(p => new GetAllProductsViewModel
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            }).ToList();
            return View(prViewModel);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel pr)
        {
            Product product = new Product
            {
                Name = pr.Name,
                Description = pr.Description,
                Price = pr.Price
            };
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return RedirectToAction("GetAllProducts");
        }

    }
}
