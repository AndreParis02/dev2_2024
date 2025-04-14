
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;

namespace _37_WebApp_SQLite.Pages.Fornitori;
public class EliminaModel : PageModel
{

    public Fornitore Fornitore { get; set; }
    public IActionResult OnGet(int id)
    {
        {
            try
            {
                var Fornitori = DbUtils.ExecuteReader(
                    "SELECT Id, Nome FROM Fornitori WHERE Id = @id",

                            reader => new Fornitore
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1)
                            },
                             cmd =>
                             {
                                 cmd.Parameters.AddWithValue("@id", id);
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


    public IActionResult OnPost(int id)
    {
         try
        {
            var Fornitori = DbUtils.ExecuteReader(
                "DELETE FROM Fornitori WHERE Id = @id",

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
        return RedirectToPage("Index");
    }

}

