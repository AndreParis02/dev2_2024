using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Template_da_pdf_a_HTML.Pages;

public class LibraryModel : PageModel
{
    private readonly ILogger<LibraryModel> _logger;

    public LibraryModel(ILogger<LibraryModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

