
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;

namespace _37_WebApp_SQLite.Pages.Fornitori;

public class DettaglioModel : PageModel
{
    public Fornitore Fornitore { get; set; }

    public IActionResult OnGet(int id)
{
         try
        {
            //Utilizzo di DbUtils per leggere la lista dei prodotti
            var Fornitori = DbUtils.ExecuteReader(
                "SELECT Id, Nome FROM Fornitori WHERE Id = @id",

                        reader => new Fornitore
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1)
                        },
                         cmd =>
                         {
                            cmd.Parameters.AddWithValue("@id",id);
                         }
            );
            Fornitore = Fornitori.First();
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return Page();
    }
    
}

