using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Category
{
    public class UpdateCateModel : PageModel
    {
        private readonly ICategoriesService _cateService;
        private readonly ILogger<UpdateCateModel> _logger;
        public UpdateCateModel(ICategoriesService categoriesService, ILogger<UpdateCateModel> logger)
        {
            _cateService = categoriesService;
            _logger = logger;
        }
        [BindProperty]
        public Categories Cate { get; set; }
        public void OnGet(int id)
        {
            Cate = _cateService.GetCategories(id);
        }
        public async Task<IActionResult> OnPostAsync(Categories model)
        {
            try
            {
                model = Cate;
                if (await _cateService.UpdateCate(model))
                {
                    return RedirectToPage("ListAllCate");
                }
                return RedirectToPage("UpdateCate");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
