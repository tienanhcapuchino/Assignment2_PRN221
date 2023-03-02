using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;
using SignalRAssignment.Pages.Category;

namespace SignalRAssignment.Pages.Supplier
{
    public class UpdateModel : PageModel
    {
        private readonly ISuplierService _suplierService;
        private readonly ILogger<UpdateCateModel> _logger;
        public UpdateModel(ISuplierService suplierService, ILogger<UpdateCateModel> logger)
        {
            _suplierService = suplierService;
            _logger = logger;
        }
        [BindProperty]
        public Suppliers Sup { get; set; }
        public void OnGet(int id)
        {
            Sup = _suplierService.GetSuppliers(id);
        }
        public async Task<IActionResult> OnPost(Suppliers model)
        {
            try
            {
                model = Sup;
                if (await _suplierService.Update(model))
                {
                    return RedirectToPage("Index");
                }
                return RedirectToPage("Add");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
