using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Core.Entity;
using Shopping.Core.Interface;

namespace SignalRAssignment.Pages.Product
{
    public class ListAllProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ILogger<ListAllProductModel> _logger;
        public ListAllProductModel(IProductService productService, ILogger<ListAllProductModel> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        public List<Products> AllProducts { get; set; }
        public Products ProductAdd { get; set; }
        public void OnGet()
        {
            try
            {
                AllProducts = _productService.GetAllProducts();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public void OnPostEdit()
        {

        }
        public void OnPostDelete()
        {

        }
    }
}
