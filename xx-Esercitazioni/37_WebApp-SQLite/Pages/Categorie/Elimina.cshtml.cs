
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;

namespace _37_WebApp_SQLite.Pages.Categorie;
public class EliminaModel : PageModel
{

    public Categoria Categoria { get; set; }
    public IActionResult OnGet(int id)
    {
        {
            try
            {
                //Utilizzo di DbUtils per leggere la lista dei prodotti
                var Categorie = DbUtils.ExecuteReader(
                    "SELECT Id, Nome FROM Categorie WHERE Id = @id",

                            reader => new Categoria
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1)
                            },
                             cmd =>
                             {
                                 cmd.Parameters.AddWithValue("@id", id);
                             }
                );
                Categoria = Categorie.First();
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
            //Utilizzo di DbUtils per leggere la lista dei prodotti
            var Categorie = DbUtils.ExecuteReader(
                "DELETE FROM Categorie WHERE Id = @id",

                        reader => new Categoria
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1)
                        },
                         cmd =>
                         {
                            cmd.Parameters.AddWithValue("@id",id);
                         }
            );
            Categoria = Categorie.First();
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return RedirectToPage("Index");
    }

}

