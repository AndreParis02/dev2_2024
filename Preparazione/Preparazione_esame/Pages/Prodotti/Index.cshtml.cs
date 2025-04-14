using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public class ProdottiModel : PageModel
{
     private readonly ILogger<ProdottiModel> _logger;
    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
        _logger.LogInformation("Prodotti Caricati");
    }

    public IEnumerable<Prodotto> Prodotti { get; set; }

    public void OnGet()
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        Prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
    }
}