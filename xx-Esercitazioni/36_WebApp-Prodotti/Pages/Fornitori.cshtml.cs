using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class FornitoriModel : PageModel
{
    private readonly ILogger<FornitoriModel> _logger;
    public FornitoriModel(ILogger<FornitoriModel> logger)
    {
        _logger = logger;
        _logger.LogInformation("Fornitori Caricati");
    }
    public IEnumerable<Fornitore> Fornitori { get; set; }

    public int numeroPagine {get;set;} 

    public void OnGet(int? pageIndex) //aggiunda di parametri per i filtri
    {
        //Lista iniziale di tutti i prodotti
        var json = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");
        var allFornitori = JsonConvert.DeserializeObject<List<Fornitore>>(json);

    numeroPagine = (int)Math.Ceiling(allFornitori.Count() / 6.0); 
 
    Fornitori = allFornitori.Skip(((pageIndex ?? 1) - 1) * 6).Take(6);
    }
}