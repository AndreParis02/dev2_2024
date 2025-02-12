using Microsoft.AspNetCore.Mvc.RazorPages; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class ProdottoDettaglioModel : PageModel
{
    private readonly ILogger<ProdottoDettaglioModel> _logger;
    
    public ProdottoDettaglioModel(ILogger<ProdottoDettaglioModel> logger)
    {
        _logger = logger;
        logger.LogInformation("Pagina del prodotto Dettaglio Caricata");
    }
    
    public Prodotto Prodotto { get; set; }
  
    public void OnGet(int id)
    {    
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json); // deserializza il file


        foreach(var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                Prodotto = prodotto;
                break;
                // Log o azioni da prendere se il prodotto non viene trovato (ad esempio, impostare un messaggio di errore)
            }
        }
    }
}
