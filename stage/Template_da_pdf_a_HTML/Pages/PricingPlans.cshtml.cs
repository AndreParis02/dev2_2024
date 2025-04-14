using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Template_da_pdf_a_HTML.Pages;

public class PricingPlansModel : PageModel
{
    private readonly ILogger<PricingPlansModel> _logger;

    public PricingPlansModel(ILogger<PricingPlansModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
