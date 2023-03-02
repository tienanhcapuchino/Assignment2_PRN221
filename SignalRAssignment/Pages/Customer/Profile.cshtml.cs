using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Customer
{
    public class ProfileModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<ProfileModel> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        public ProfileModel(IOrderService orderService, ILogger<ProfileModel> logger, IHttpContextAccessor contextAccessor)
        {
            _orderService = orderService;
            _logger = logger;
            _contextAccessor = contextAccessor;
        }
        [BindProperty]
        public List<Orders> Histories { get; set; }
        public void OnGet()
        {
            var user = _contextAccessor.HttpContext.Session.GetString("customer");
            var cusId = JsonConvert.DeserializeObject<Customers>(user).CustomerId;
            Histories = _orderService.GetByCusId(cusId);
        }
    }
}
