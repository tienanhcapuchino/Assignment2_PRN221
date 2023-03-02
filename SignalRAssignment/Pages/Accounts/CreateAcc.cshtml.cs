using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Accounts
{
    public class CreateAccModel : PageModel
    {
        private IAccountService _accountService;
        private ILogger<UpdateAccModel> _logger;
        public CreateAccModel(IAccountService accountService, ILogger<UpdateAccModel> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }
        [BindProperty]
        public Account Accou { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(Account model)
        {
            try
            {
                model = Accou;
                if (await _accountService.AddAcc(model))
                {
                    return RedirectToPage("ListAllAccounts");
                }
                return RedirectToPage("CreateAcc");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
