using Microsoft.AspNetCore.Mvc.RazorPages; 
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class CreateModel : PageModel
{
    public List<string> Categorie { get; set; }

    public void OnGet()
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        Categorie = JsonConvert.DeserializeObject<List<string>>(json);

    }

    public IActionResult OnPost(string nome, decimal prezzo, int quantita, string categoria)
    {
        var path = "wwwroot/json/prodotti.json";
        List<Prodotto> prodotti;

        if (System.IO.File.Exists(path))
        {
            var json = System.IO.File.ReadAllText(path);
            prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json) ?? new List<Prodotto>();
        }
        else
        {
            prodotti = new List<Prodotto>();
        }

        var id = 1;
        if (prodotti.Count > 0)
        {
            id = prodotti[^1].Id + 1; // usa ^1 per prendere l'ultimo elemento (C# 8+)
        }

        prodotti.Add(new Prodotto
        {
            Id = id,
            Nome = nome,
            Prezzo = prezzo,
            Quantita = quantita,
            Categoria = categoria,
            Data = DateTime.Now
        });

        System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(prodotti, Formatting.Indented));

        return RedirectToPage("Index");
    }
}
