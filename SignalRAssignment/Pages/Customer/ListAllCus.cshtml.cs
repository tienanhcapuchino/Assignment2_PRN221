using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Customer
{
    public class ListAllCusModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<ListAllCusModel> _logger;
        public ListAllCusModel(ICustomerService customerService, ILogger<ListAllCusModel> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }
        [BindProperty]
        public List<Customers> AllCuses { get; set; }
        public void OnGet()
        {
            AllCuses = _customerService.GetAllCustomers();
        }
    }
}
