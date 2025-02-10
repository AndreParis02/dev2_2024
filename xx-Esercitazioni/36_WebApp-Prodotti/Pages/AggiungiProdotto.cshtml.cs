using Microsoft.AspNetCore.Mvc.RazorPages; 
using Microsoft.AspNetCore.Mvc; 
using Newtonsoft.Json;


public class AggiungiProdottoModel : PageModel
{
    public List<string> Categorie {get;set;}
    
    public void OnGet()
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        Categorie = JsonConvert.DeserializeObject<List<string>>(json);

    }
    public IActionResult OnPost(string nome, decimal prezzo, string dettaglio, int quantita ,string categoria, string immagine, DateTime data)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        
        var id = 1;
        if(prodotti.Count > 0)
        {
            id = prodotti[prodotti.Count - 1].Id +1;
        }
        prodotti.Add(new Prodotto {Id = id, Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio, Quantita = quantita, Categoria = categoria, Immagine = immagine, Data = DateTime.Now});
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti));
        return RedirectToPage("Prodotti");
    }
}