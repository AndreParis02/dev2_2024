using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _34_WebApp.Pages;

public class ProdottiModel : PageModel
{
    string parametro = "errore 404";
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
        _logger.LogInformation("Pagina dei prodotti");
        _logger.LogInformation("Messaggio di log con parametro {0}",parametro);
    }

    public void OnGet()
    {
        ViewData["Message"] = $"Messaggio di log con {parametro}";
    }
}

