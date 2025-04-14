using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class DeleteModel : PageModel
{
    private readonly ILogger<DeleteModel> _logger;
    public DeleteModel (ILogger<DeleteModel> logger)
    {
        _logger = logger;
    }
    public Prodotto Prodotto { get; set; }

    [TempData]
    public string messaggio {get;set;}

    public void OnGet(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                Prodotto = prodotto;
                break;
            }
        }  
    }

    public IActionResult OnPost(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json); 
        for (int i = 0; i < prodotti.Count;i++)
        {
            if (prodotti[i].Id == id)
            {
                prodotti.RemoveAt(i);
                break;
            }
        }
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        messaggio = "Prodotto Eliminato con successo";
        TempData.Keep(messaggio);
        return RedirectToPage("/Prodotti/Index");
    }
}