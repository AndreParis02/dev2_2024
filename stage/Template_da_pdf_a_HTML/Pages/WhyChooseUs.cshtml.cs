using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Template_da_pdf_a_HTML.Pages;

public class WhyChooseUsModel : PageModel
{
    private readonly ILogger<WhyChooseUsModel> _logger;

    public WhyChooseUsModel(ILogger<WhyChooseUsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

