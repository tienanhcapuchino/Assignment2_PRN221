using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Supplier
{
    public class IndexModel : PageModel
    {
        private readonly ISuplierService _supplierService;
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ISuplierService supplierService, ILogger<IndexModel> logger)
        {
            _supplierService = supplierService;
            _logger = logger;
        }
        [BindProperty]
        public List<Suppliers> AllSup { get; set; }
        public void OnGet()
        {
            AllSup = _supplierService.GetAll();
        }
        public IActionResult OnPost(int supId)
        {
            try
            {
                _supplierService.Delete(supId);
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
