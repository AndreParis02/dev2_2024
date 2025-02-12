using Microsoft.AspNetCore.Mvc.RazorPages; 
using Microsoft.AspNetCore.Mvc; 
using Newtonsoft.Json;


public class AggiungiFornitoreModel : PageModel
{
    public List<string> Categorie {get;set;}

    [TempData]
    public string messaggio {get;set;}
    
    public void OnGet()
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        Categorie = JsonConvert.DeserializeObject<List<string>>(json);

    }
    public IActionResult OnPost(string nome,string categoria)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");
        var fornitori = JsonConvert.DeserializeObject<List<Fornitore>>(json);
        
        var id = 1;
        if(fornitori.Count > 0)
        {
            id = fornitori[fornitori.Count - 1].Id +1;
        }
        fornitori.Add(new Fornitore {Id = id, Nome = nome, Categoria = categoria});
        System.IO.File.WriteAllText("wwwroot/json/fornitori.json", JsonConvert.SerializeObject(fornitori));
        
        messaggio = "Fornitore Aggiunto con successo";
        TempData.Keep(messaggio);

        return RedirectToPage("Fornitori");
    }
}