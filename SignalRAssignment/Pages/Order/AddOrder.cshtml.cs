using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Order
{
    public class AddOrderModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly ILogger<AddOrderModel> _logger;
        public AddOrderModel(IOrderService orderService,
            ICustomerService customerService,
            ILogger<AddOrderModel> logger)
        {
            _orderService = orderService;
            _customerService = customerService;
            _logger = logger;
        }
        [BindProperty]
        public Orders Ord { get; set; }
        public List<Customers> Customers { get; set; }
        public void OnGet()
        {
            Customers = _customerService.GetAllCustomers();
        }
        public async Task<IActionResult> OnPostAsync(Orders or)
        {
            try
            {
                or = Ord;
                if (await _orderService.AddOrder(or))
                {
                    return RedirectToPage("ListAllOrders");
                }
                return RedirectToPage("AddOrder");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
