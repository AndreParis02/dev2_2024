using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;

namespace _37_WebApp_SQLite.Pages.Categorie;
public class ModificaModel : PageModel
{
    [BindProperty]
    public Categoria Categoria { get; set; }
    public IActionResult OnGet(int id)
    {
        try
        {
            var Categorie = DbUtils.ExecuteReader(
                "Select Id, Nome FROM Categorie WHERE Id = @id",
                reader => new Categoria
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                }
          ,
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
        //restituisce la pagina con i dati del prodotto da modificare
        return Page();

    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();

        }
        try
        {
            DbUtils.ExecuteNonQuery(
                "UPDATE Categorie SET Nome = @nome WHERE Id = @id",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@nome", Categoria.Nome);
                    cmd.Parameters.AddWithValue("@id", Categoria.Id);
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
            return Page();
        }
        return RedirectToPage("Index");
    }
}