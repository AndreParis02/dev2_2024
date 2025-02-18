using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; //in modo da usare SelectListItem
using System.Data.SqlClient;
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;

namespace _37_WebApp_SQLite.Pages.Prodotti;
public class DettaglioModel : PageModel
{
    public ProdottoViewModel Prodotto { get; set; }
    public IActionResult OnGet(int id)
    {
         try
        {
            //Utilizzo di DbUtils per leggere la lista dei prodotti
            var Prodotti = DbUtils.ExecuteReader(
                "Select p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id WHERE p.Id = @id",

                        reader => new ProdottoViewModel //lettura risultato query
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Prezzo = reader.GetDouble(2),
                            CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)  
                        },
                         cmd =>
                         {
                            cmd.Parameters.AddWithValue("@id",id); //assegnazione parametro passato dall'OnGet e non conosciuto dal reader (per questo separiamo il reader dal cmd)
                         }
            );
            Prodotto = Prodotti.First(); 
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return Page();
    }
}