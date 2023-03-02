using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Customer
{
    public class ProfileModel : PageModel
    {
        private readonly ILogger<ProfileModel> _logger;
        private readonly ICustomerService _customerService;
        private readonly IHttpContextAccessor _contextAccessor;
        public ProfileModel(ILogger<ProfileModel> logger,
            IHttpContextAccessor contextAccessor,
            ICustomerService customerService)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
            _customerService = customerService;
        }
        [BindProperty]
        public Customers Cus { get; set; }
        [BindProperty(Name = "message", SupportsGet = true)]
        public string MessageError { get; set; }

        public void OnGet(string message)
        {
            this.MessageError = message;
            var user = _contextAccessor.HttpContext.Session.GetString("customer");
            var cusId = JsonConvert.DeserializeObject<Customers>(user).CustomerId;
            Cus = _customerService.GetCustomerById(cusId);
        }
        public async Task<IActionResult> OnPostAsync(Customers customers)
        {
            try
            {
                customers = Cus;
                if (await _customerService.UpdateProfile(customers))
                {
                    return RedirectToPage("Profile", new { message = "update success!" });
                }
                return RedirectToPage("Profile", new { message = "update failed!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
