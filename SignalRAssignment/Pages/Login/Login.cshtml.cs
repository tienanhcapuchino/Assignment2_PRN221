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
        public LoginModel(IAccountService accountService, ILogger<LoginModel> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }
        [BindProperty]
        public UserLoginModel UserLogin { get; set; }
        [BindProperty(Name = "message", SupportsGet = true)]
        public string MessageError { get; set; }
        public void OnGet(string message)
        {
            this.MessageError = message;
        }
        public async Task<IActionResult> OnPostAsync(UserLoginModel model)
        {
            try
            {
                model = UserLogin;
                if (await _accountService.Login(model))
                {
                    var users = await _accountService.GetAccountByUsername(model.Username);

                    if (users != null)
                    {
                        string jsonStr = JsonConvert.SerializeObject(users);
                        HttpContext.Session.SetString("user", jsonStr);
                        return RedirectToPage("/Index");
                    }
                }
                var admin = await _accountService.IsAdmin(model);
                if (admin)
                {
                    string jsonStr = JsonConvert.SerializeObject(admin);
                    HttpContext.Session.SetString("admin", jsonStr);
                    return RedirectToPage("/Product/ListAllProduct");
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
