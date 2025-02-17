using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;
namespace _37_WebApp_SQLite.Pages.Prodotti;

public class SearchModel : PageModel
{
    //abbiamo bisogno di una proprieta pubblica
    public string SearchTerm { get; set; }
    public List<ProdottoViewModel> Prodotti { get; set; } = new List<ProdottoViewModel>();
    public void OnGet(string q)
    {
        //assegno la stringa di ricerca alla proprieta pubblica
        SearchTerm = q;

        //se la stringa di ricerca non è vuota
        if (!string.IsNullOrWhiteSpace(q))
        {
            try
            {
                //Utilizzo di DbUtils per leggere la lista dei prodotti
                Prodotti = DbUtils.ExecuteReader(
                    "SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id WHERE p.Nome LIKE @searchTerm",

                            reader => new ProdottoViewModel
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Prezzo = reader.GetDouble(2),
                                CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                            },
                             cmd =>
                             {
                                 cmd.Parameters.AddWithValue("@searchTerm", $"%{q}%");
                             }
                );
            }
            catch (Exception ex)
            {
                SimpleLogger.Log(ex);
            }

        }
    }
}