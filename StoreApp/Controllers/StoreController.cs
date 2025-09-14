using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApp.Context;
using StoreApp.Models.Entities.Concretes;
using StoreApp.ViewModel;
using StoreApp.ViewModel.CategoyViewModels;
using StoreApp.ViewModel.OrderViewModels;

namespace StoreApp.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreAppDbContext _dbContext;


        public StoreController(StoreAppDbContext context)
        {
            _dbContext = context;
        }
        #region Product
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _dbContext.Products.ToList();
            var prViewModel = products.Select(p => new GetAllProductsViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryName = _dbContext.Categories.FirstOrDefault(c => c.Id == p.CategoryId)?.Name
            }).ToList();
            return View(prViewModel);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            var ctViewModel = _dbContext.Categories.Select(c => new GetAllCategoriesViewModels
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            ViewBag.Categories = new SelectList(ctViewModel, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel pr)
        {
            var ct = _dbContext.Categories.FirstOrDefault(c => c.Id == pr.CategoryId);
            Product product = new Product
            {
                Name = pr.Name,
                Description = pr.Description,
                Price = pr.Price,
                Category = ct
            };
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return RedirectToAction("GetAllProducts");
        }
        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product is not null)
                _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("GetAllProducts");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product is null)
                return RedirectToAction("GetAllProducts");
            UpdateProductViewModel prViewModel = new UpdateProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,

            };
            var ctViewModel = _dbContext.Categories.Select(c => new GetAllCategoriesViewModels
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            ViewBag.Categories = new SelectList(ctViewModel, "Id", "Name");
            return View(prViewModel);
        }
        [HttpPost]
        public IActionResult UpdateProduct(int id, UpdateProductViewModel pr)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product is null)
                return RedirectToAction("GetAllProducts");
            product.Name = pr.Name;
            product.Description = pr.Description;
            product.Price = pr.Price;
            product.CategoryId = pr.CategoryId;
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return RedirectToAction("GetAllProducts");
        }
        #endregion
        #region Category
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _dbContext.Categories.ToList();
            var ctViewModel = categories.Select(p => new GetAllCategoriesViewModels
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
            return View(ctViewModel);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel pr)
        {
            Category ct = new Category
            {
                Name = pr.Name
            };
            _dbContext.Categories.Add(ct);
            _dbContext.SaveChanges();
            return RedirectToAction("GetAllCategories");
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            var ct = _dbContext.Categories.FirstOrDefault(p => p.Id == id);
            if (ct is not null)
                _dbContext.Categories.Remove(ct);
            _dbContext.SaveChanges();
            return RedirectToAction("GetAllCategories");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var ct = _dbContext.Categories.FirstOrDefault(p => p.Id == id);
            if (ct is null)
                return RedirectToAction("GetAllCategories");
            AddCategoryViewModel ctViewModel = new AddCategoryViewModel
            {
                Name = ct.Name
            };
            return View(ctViewModel);
        }
        [HttpPost]
        public IActionResult UpdateCategory(int id, AddCategoryViewModel ct)
        {
            var category = _dbContext.Categories.FirstOrDefault(p => p.Id == id);
            if (category is null)
                return RedirectToAction("GetAllCategories");
            category.Name = ct.Name;
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
            return RedirectToAction("GetAllCategories");
        }

        #endregion

      
    }
}
