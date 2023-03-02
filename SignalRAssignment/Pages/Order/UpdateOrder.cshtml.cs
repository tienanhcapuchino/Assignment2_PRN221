using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Order
{
    public class UpdateOrderModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly ILogger<AddOrderModel> _logger;
        public UpdateOrderModel(IOrderService orderService,
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
        public void OnGet(int id)
        {
            Customers = _customerService.GetAllCustomers();
            Ord = _orderService.GetOrderById(id);
        }
        public async Task<IActionResult> OnPostAsync(Orders or)
        {
            try
            {
                or = Ord;
                if (await _orderService.UpdateOrder(or))
                {
                    return RedirectToPage("ListAllOrders");
                }
                return RedirectToPage("UpdateOrder");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
