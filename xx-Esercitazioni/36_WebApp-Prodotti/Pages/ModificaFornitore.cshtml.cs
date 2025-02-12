using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class ModificaFornitoreModel : PageModel
{
    private readonly ILogger<ModificaFornitoreModel> _logger;

    public ModificaFornitoreModel(ILogger<ModificaFornitoreModel>logger)
    {
        _logger = logger;
    }
    public Fornitore Fornitore {get; set;}

    public List<string> Categorie {get;set;}

    [TempData]
    public string messaggio {get;set;}
    public void OnGet(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");
        var fornitori = JsonConvert.DeserializeObject<List<Fornitore>>(json);

        var json2 = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        Categorie = JsonConvert.DeserializeObject<List<string>>(json2);

        foreach(var fornitore in fornitori)
        {
            bool aggiungi = true;

            //applichiamo il filtro per minPrezzo se presente
            if(fornitore.Id == id)
            {
               Fornitore = fornitore;
               break;
            }
        }
    }

    public IActionResult OnPost(int id, string nome, string categoria)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");
        var fornitori = JsonConvert.DeserializeObject<List<Fornitore>>(json);
        Fornitore fornitore = null;
        
        foreach(var f in fornitori)
        {
           if(f.Id == id)
           {
                fornitore = f;
                break;
           } 
        }
        if(fornitore == null)
        {
            return NotFound();
        }

        fornitore.Nome = nome;
        fornitore.Categoria = categoria;
 

        System.IO.File.WriteAllText("wwwroot/json/fornitori.json", JsonConvert.SerializeObject(fornitori, Formatting.Indented));
        messaggio = "Fornitore Modificato con successo";
        TempData.Keep(messaggio);
        return RedirectToPage("Fornitori");
    }
}