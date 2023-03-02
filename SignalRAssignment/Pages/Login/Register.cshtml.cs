using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;
using SignalRAssignment.Models;
using SignalRAssignment.Pages.Login;

namespace ShoppingWeb.Pages.Login
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<RegisterModel> _logger;
        public RegisterModel(IAccountService accountService, ILogger<RegisterModel> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }
        [BindProperty]
        public Account Acc { get; set; }
        [BindProperty(Name = "message", SupportsGet = true)]
        public string MessageError { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(Account accModel)
        {
            try
            {
                accModel = Acc;
                if (await _accountService.RegisterAccount(accModel))
                {
                    UserLoginModel userLogged = new UserLoginModel()
                    {
                        Username = accModel.Username,
                        Password = accModel.Password
                    };
                    var account = await _accountService.GetAccountByUsername(accModel.Username);
                    string jsonStr = JsonConvert.SerializeObject(account);
                    HttpContext.Session.SetString("user", jsonStr);
                    return RedirectToPage("/Index");
                }

                return RedirectToPage("Register", new { message = "Register failed" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
