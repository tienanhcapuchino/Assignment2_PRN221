using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Core.Entity;
using Shopping.Core.Interface;

namespace SignalRAssignment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _productService;
        private readonly ICategoriesService _categoriesService;

        public IndexModel(ILogger<IndexModel> logger,
            IProductService productService,
            ICategoriesService categoriesService)
        {
            _logger = logger;
            _productService = productService;
            _categoriesService = categoriesService;
        }
        public List<Products> AllProducts { get; set; }
        public List<Categories> Categories { get; set; }

        public void OnGet(string? searhName, int? cateId)
        {
            try
            {
                Categories = _categoriesService.GetAllCategoriesName();
                AllProducts = _productService.GetAllProducts();
                if (!string.IsNullOrEmpty(searhName))
                {
                    ViewData["SearchName"] = searhName;
                    AllProducts = AllProducts.Where(x => x.ProductName.ToLower().Contains(searhName.ToLower())).ToList();
                }
                if (cateId != null)
                {
                    AllProducts = AllProducts.Where(x => x.CategoryId == cateId).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }
    }
}