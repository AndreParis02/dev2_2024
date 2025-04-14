using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Template_da_pdf_a_HTML.Pages;

public class ServicesModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public ServicesModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

