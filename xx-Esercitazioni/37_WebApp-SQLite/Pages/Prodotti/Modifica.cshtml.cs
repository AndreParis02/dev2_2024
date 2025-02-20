using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; //in modo da usare SelectListItem
using System.Data.SQLite;
using _37_WebApp_SQLite.Utilities;
using _37_WebApp_SQLite.Models;

namespace _37_WebApp_SQLite.Pages.Prodotti;

public class ModificaModel : PageModel
{
    [BindProperty]
    public Prodotto Prodotto { get; set; }
    public List<SelectListItem> CategorieSelectList { get; set; } = new List<SelectListItem>();
    //passo l'id come parametro perchè voglio modificare un prodotto esistente sul quale ho cliccato in precedenza
    public IActionResult OnGet(int id)
    {
        try
        {
            //Utilizzo di DbUtils per leggere la lista dei prodotti
            var Prodotti = DbUtils.ExecuteReader(
                "SELECT Id, Nome, Prezzo, CategoriaId FROM Prodotti WHERE Id = @id",

                        reader => new Prodotto
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Prezzo = reader.GetDouble(2),
                            IdCategoria = reader.GetInt32(3)
                        },
                         cmd =>
                         {
                            cmd.Parameters.AddWithValue("@id",id);
                         }
            );
            Prodotto = Prodotti.First();
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        //carico le categorie in modo da poterle visualizzare nella select list
        CaricaCategorie();
        //restituisco la pagina con i dati del prodotto da modificare

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            //se il modello non è valido carico le categorie e restituisco la pagina
            CaricaCategorie();
            return Page();
        }
        try
        {
            DbUtils.ExecuteNonQuery(
                "UPDATE Prodotti SET Nome = @nome, Prezzo = @prezzo, CategoriaId = @categoria WHERE Id = @id",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@nome", Prodotto.Nome);
                    cmd.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
                    cmd.Parameters.AddWithValue("@categoria", Prodotto.IdCategoria);
                    cmd.Parameters.AddWithValue("@id", Prodotto.Id);
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
            CaricaCategorie();
            return Page();
        }
        return RedirectToPage("PagedIndex");
    }

    //metodo per caricare le categorie
    private void CaricaCategorie()
    {
        try
        {
            //Utilizzo di DbUtils per leggere la lista dei prodotti
            CategorieSelectList = DbUtils.ExecuteReader(
                "SELECT Id, Nome FROM Categorie",
                reader => new SelectListItem
                {
                    Value = reader.GetInt32(0).ToString(),
                    Text = reader.GetString(1)
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }
}