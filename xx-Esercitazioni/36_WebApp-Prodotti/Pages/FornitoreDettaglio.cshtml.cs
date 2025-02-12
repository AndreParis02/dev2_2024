using Microsoft.AspNetCore.Mvc.RazorPages; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class FornitoreDettaglioModel : PageModel
{
    private readonly ILogger<FornitoreDettaglioModel> _logger;
    
    public FornitoreDettaglioModel(ILogger<FornitoreDettaglioModel> logger)
    {
        _logger = logger;
        logger.LogInformation("Pagina del fornitore Dettaglio Caricata");
    }
    
    public Fornitore Fornitore { get; set; }
    
    public void OnGet(int id)
    {    
        var json = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");
        var fornitori = JsonConvert.DeserializeObject<List<Fornitore>>(json); // deserializza il file
        foreach(var fornitore in fornitori)
        {
            if (fornitore.Id == id)
            {
                Fornitore = fornitore;
                break;
                // Log o azioni da prendere se il fornitore non viene trovato (ad esempio, impostare un messaggio di errore)
            }
        }
    }
}
