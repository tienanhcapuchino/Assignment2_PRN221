using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shopping.Core.Interface;
using Shopping.Core.Models;

namespace SignalRAssignment.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        public LoginModel(IAccountService accountService, ILogger<LoginModel> logger, ICustomerService customerService)
        {
            _accountService = accountService;
            _logger = logger;
            _customerService = customerService;
        }
        [BindProperty]
        public UserLoginModel UserLogin { get; set; }
        [BindProperty(Name = "message", SupportsGet = true)]
        public string MessageError { get; set; }
        public void OnGet(string message)
        {
            this.MessageError = message;
        }
        public void OnPostLog()
        {
            HttpContext.Session.Clear();
        }
        public async Task<IActionResult> OnPostAsync(UserLoginModel model)
        {
            try
            {
                model = UserLogin;
                var users = await _accountService.GetAccountByUsername(model.Username);
                if (await _accountService.Login(model))
                {
                    string jsonStr = JsonConvert.SerializeObject(users);
                    HttpContext.Session.SetString("user", jsonStr);
                    if (users.Type == 2)
                        return RedirectToPage("/Index");
                    if (users.Type == 1)
                        return RedirectToPage("/Product/ListAllProduct");
                }
                if (await _customerService.Login(model.Username, model.Password))
                {
                    var customer = _customerService.GetCustomerByPhone(model.Username);
                    string jsonStr = JsonConvert.SerializeObject(customer);
                    HttpContext.Session.SetString("customer", jsonStr);
                    return RedirectToPage("/Index");
                } 
                return RedirectToPage("Login", new { message = "Login failed" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
