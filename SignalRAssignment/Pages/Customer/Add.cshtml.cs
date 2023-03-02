using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Customer
{
    public class AddModel : PageModel
    {
        private readonly ILogger<AddModel> _logger;
        private readonly ICustomerService _customerService;
        public AddModel(ILogger<AddModel> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }
        [BindProperty]
        public Customers Customers { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(Customers cus)
        {
            try
            {
                cus = Customers;
                if (await _customerService.AddNewCus(cus))
                {
                    return RedirectToPage("ListAllCus");
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
