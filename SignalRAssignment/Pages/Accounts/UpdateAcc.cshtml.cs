using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Accounts
{
    public class UpdateAccModel : PageModel
    {
        private IAccountService _accountService;
        private ILogger<UpdateAccModel> _logger;
        public UpdateAccModel(IAccountService accountService, ILogger<UpdateAccModel> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }
        [BindProperty]
        public Account Acc { get; set; }

        public void OnGet(int id)
        {
            Acc = _accountService.GetById(id);
        }
        public async Task<IActionResult> OnPostAsync(Account model)
        {
            try
            {
                model = Acc;
                if (await _accountService.UpdateAcc(model))
                {
                    return RedirectToPage("ListAllAccounts");
                }
                return RedirectToPage("UpdateAcc");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
