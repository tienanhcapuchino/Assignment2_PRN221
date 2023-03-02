using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;
using Microsoft.AspNetCore.Http;

namespace SignalRAssignment.Pages.Product
{
    public class ListAllProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ILogger<ListAllProductModel> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        public ListAllProductModel(IProductService productService, ILogger<ListAllProductModel> logger, IHttpContextAccessor contextAccessor)
        {
            _productService = productService;
            _logger = logger;
            _contextAccessor = contextAccessor;
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
        public IActionResult OnPostDelete(int prId)
        {
            try
            {
                _productService.DeleteProduct(prId);
                return RedirectToPage("ListAllProduct");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
