using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class CancellaFornitoreModel : PageModel
{
    private readonly ILogger<CancellaFornitoreModel> _logger;
    public CancellaFornitoreModel(ILogger<CancellaFornitoreModel> logger)
    {
        _logger = logger;
    }
    public Fornitore Fornitore { get; set; }

    [TempData]
    public string messaggio {get;set;}

    public void OnGet(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");
        var fornitori = JsonConvert.DeserializeObject<List<Fornitore>>(json);
        foreach (var fornitore in fornitori)
        {
            if (fornitore.Id == id)
            {
                Fornitore = fornitore;
                break;
            }
        }  
    }

    public IActionResult OnPost(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");
        var fornitori = JsonConvert.DeserializeObject<List<Fornitore>>(json); 
        for (int i = 0; i < fornitori.Count;i++)
        {
            if (fornitori[i].Id == id)
            {
                fornitori.RemoveAt(i);
                break;
            }
        }
        System.IO.File.WriteAllText("wwwroot/json/fornitori.json", JsonConvert.SerializeObject(fornitori, Formatting.Indented));
        messaggio = "Fornitore Eliminato con successo";
        TempData.Keep(messaggio);
        return RedirectToPage("/Fornitori");
    }
}