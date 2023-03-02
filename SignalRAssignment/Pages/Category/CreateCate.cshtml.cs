using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Category
{
    public class CreateCateModel : PageModel
    {
        private readonly ICategoriesService _cateService;
        private readonly ILogger<CreateCateModel> _logger;
        public CreateCateModel(ICategoriesService cateService, ILogger<CreateCateModel> logger)
        {
            _cateService = cateService;
            _logger = logger;
        }
        [BindProperty]
        public Categories Cate { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(Categories model)
        {
            try
            {
                model = Cate;
                if (await _cateService.AddNew(model))
                {
                    return RedirectToPage("ListAllCate");
                }
                return RedirectToPage("CreateCate");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
