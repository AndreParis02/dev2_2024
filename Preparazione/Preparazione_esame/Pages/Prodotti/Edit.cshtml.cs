using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class EditModel : PageModel
{
    private readonly ILogger<EditModel> _logger;

    public EditModel(ILogger<EditModel> logger)
    {
        _logger = logger;
    }
    public Prodotto Prodotto { get; set; }

    public List<string> Categorie { get; set; }

    [TempData]
    public string messaggio { get; set; }
    public void OnGet(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        var json2 = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        Categorie = JsonConvert.DeserializeObject<List<string>>(json2);



        foreach (var prodotto in prodotti)
        {
            bool aggiungi = true;

            if (prodotto.Id == id)
            {
                Prodotto = prodotto;
                break;
            }
        }
    }

    public IActionResult OnPost(int id, string nome, decimal prezzo, int quantita, string categoria)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        Prodotto prodotto = null;

        foreach (var p in prodotti)
        {
            if (p.Id == id)
            {
                prodotto = p;
                break;
            }
        }
        if (prodotto == null)
        {
            return NotFound();
        }

        prodotto.Nome = nome;
        prodotto.Prezzo = prezzo;
        prodotto.Categoria = categoria;
        prodotto.Quantita = quantita;

        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        messaggio = "Prodotto Modificato con successo";
        TempData.Keep(messaggio);
        return RedirectToPage("/Prodotti/Index");
    }
}