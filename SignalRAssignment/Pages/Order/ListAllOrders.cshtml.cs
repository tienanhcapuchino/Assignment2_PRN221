using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Order
{
    public class ListAllOrdersModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly ILogger<ListAllOrdersModel> _logger;
        public ListAllOrdersModel(IOrderService orderService, ICustomerService customerService, ILogger<ListAllOrdersModel> logger)
        {
            _orderService = orderService;
            _customerService = customerService;
            _logger = logger;
        }
        public List<Customers> Customers { get; set; }
        public List<Orders> Orders { get; set; }
        public void OnGet()
        {
            Customers = _customerService.GetAllCustomers();
            Orders = _orderService.GetAll();
        }
        public IActionResult OnPost(int orId)
        {
            try
            {
                _orderService.DeleteOrder(orId);
                return RedirectToPage("ListAllOrders");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
