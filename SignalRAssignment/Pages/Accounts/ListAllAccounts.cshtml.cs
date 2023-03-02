using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Accounts
{
    public class ListAllAccountsModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<ListAllAccountsModel> _logger;
        public ListAllAccountsModel(IAccountService accountService, ILogger<ListAllAccountsModel> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }
        [BindProperty]
        public List<Account> AllAcc { get; set; }
        public void OnGet()
        {
            AllAcc = _accountService.GetAccounts();
        }
        public IActionResult OnPost(int accId)
        {
            try
            {
                _accountService.RemoveAcc(accId);
                return RedirectToPage("ListAllAccounts");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
