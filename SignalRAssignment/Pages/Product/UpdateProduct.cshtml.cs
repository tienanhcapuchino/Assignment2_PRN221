using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Product
{
    public class UpdateProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoriesService _categoriesService;
        private readonly ISuplierService _suplierService;
        public UpdateProductModel(IProductService productService,
            ICategoriesService categoriesService,
            ISuplierService suplierService)
        {
            _productService = productService;
            _categoriesService = categoriesService;
            _suplierService = suplierService;
        }
        public List<Categories> Categories { get; set; }
        public List<Suppliers> Suppliers { get; set; }
        [BindProperty]
        public Products Pro { get; set; }
        public void OnGet(int id)
        {
            try
            {
                Pro = _productService.GetProductById(id);
                Categories = _categoriesService.GetAllCategoriesName();
                Suppliers = _suplierService.GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IActionResult OnPost(Products model)
        {
            try
            {
                model = Pro;
                if (_productService.UpdateProduct(model).Result)
                {
                    return RedirectToPage("ListAllProduct");
                }
                return RedirectToPage("UpdateProduct");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
