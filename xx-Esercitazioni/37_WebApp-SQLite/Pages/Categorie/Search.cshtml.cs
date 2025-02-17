using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;
namespace _37_WebApp_SQLite.Pages.Categorie;
public class SearchModel : PageModel
{
    //abbiamo bisogno di una proprieta pubblica
    public string SearchTerm {get; set;}
    public List<Categoria> Categorie {get; set;} = new List<Categoria>();
    public void OnGet(string q)
    {
        SearchTerm = q;
        if (!string.IsNullOrWhiteSpace(q))
        {
            Categorie = DbUtils.ExecuteReader(
                "SELECT Id, Nome FROM Categorie WHERE Nome LIKE @searchTerm",
                reader => new Categoria
                {
                    Id= reader.GetInt32(0),
                    Nome= reader.GetString(1)
                },
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@searchTerm", $"%{q}%");
                }
            );
        }
    }
}