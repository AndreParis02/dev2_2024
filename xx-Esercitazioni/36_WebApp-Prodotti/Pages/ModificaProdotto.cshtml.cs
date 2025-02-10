using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class ModificaProdottoModel : PageModel
{
    private readonly ILogger<ModificaProdottoModel> _logger;

    public ModificaProdottoModel(ILogger<ModificaProdottoModel>logger)
    {
        _logger = logger;
    }
    public Prodotto Prodotto {get; set;}

    public List<string> Categorie {get;set;}
    public void OnGet(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        var json2 = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        Categorie = JsonConvert.DeserializeObject<List<string>>(json2);

        foreach(var prodotto in prodotti)
        {
            bool aggiungi = true;

            //applichiamo il filtro per minPrezzo se presente
            if(prodotto.Id == id)
            {
               Prodotto = prodotto;
               break;
            }
        }
    }

    public IActionResult OnPost(int id, string nome, decimal prezzo, string dettaglio, int quantita ,string categoria, string immagine)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        Prodotto prodotto = null;
        
        foreach(var p in prodotti)
        {
           if(p.Id == id)
           {
                prodotto = p;
                break;
           } 
        }
        if(prodotto == null)
        {
            return NotFound();
        }

        prodotto.Nome = nome;
        prodotto.Prezzo = prezzo;
        prodotto.Dettaglio = dettaglio;
        prodotto.Categoria = categoria;
        prodotto.Quantita = quantita;
        prodotto.Immagine = immagine;

        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToPage("Prodotti");
    }
}