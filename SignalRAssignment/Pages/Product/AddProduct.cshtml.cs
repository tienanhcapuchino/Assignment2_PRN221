using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Product
{
    public class AddProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoriesService _categoriesService;
        private readonly ISuplierService _suplierService;
        public AddProductModel(IProductService productService,
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
        public void OnGet()
        {
            Categories = _categoriesService.GetAllCategoriesName();
            Suppliers = _suplierService.GetAll();
        }
        public IActionResult OnPost(Products pro)
        {
            pro = Pro;
            if (_productService.AddProduct(pro).Result)
            {
                return RedirectToPage("ListAllProduct");
            }
            return RedirectToPage("AddProduct");
        }
    }
}
