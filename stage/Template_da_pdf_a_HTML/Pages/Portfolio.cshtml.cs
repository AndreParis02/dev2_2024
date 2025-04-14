using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Template_da_pdf_a_HTML.Pages;

public class PortfolioModel : PageModel
{
    private readonly ILogger<PortfolioModel> _logger;

    public PortfolioModel(ILogger<PortfolioModel> logger)
    {
        _logger = logger;
    }

    public string Selected { get; set; }
    public void OnGet(string selected)
    {

        Selected = "All";

        if(Selected != null)
        {
            Selected = selected;
        }
    }
}
