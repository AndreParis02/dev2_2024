using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;

namespace _37_WebApp_SQLite.Pages.Categorie;

public class CategorieModel : PageModel
{

    public List<Categoria> Categorie { get; set; } = new List<Categoria>();

    public void OnGet()
    {

        try
        {
            //Utilizzo di DbUtils per leggere la lista dei prodotti
            Categorie = DbUtils.ExecuteReader(
                "SELECT Id, Nome FROM Categorie",
                reader => new Categoria
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

    }
}