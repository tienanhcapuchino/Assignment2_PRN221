using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;

namespace SignalRAssignment.Pages.Category
{
    public class ListAllCateModel : PageModel
    {
        private readonly ICategoriesService _cateService;
        private ILogger<ListAllCateModel> _logger;
        public ListAllCateModel(ICategoriesService cateService, ILogger<ListAllCateModel> logger)
        {
            _cateService = cateService;
            _logger = logger;
        }
        [BindProperty]
        public List<Categories> ListAll { get; set; }
        public void OnGet()
        {
            ListAll = _cateService.GetAllCategoriesName();
        }
        public IActionResult OnPost(int cateId)
        {
            try
            {
                _cateService.DeleteCate(cateId);
                return RedirectToPage("ListAllCate");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
