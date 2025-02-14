using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
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
            using var connection = DatabaseInitializer.GetConnection();
            connection.Open();

            var sql= @"SELECT Id, Nome FROM Categorie WHERE Nome LIKE @searchTerm";

           
            using var command = new SQLiteCommand(sql, connection);
            command.Parameters.AddWithValue("@searchTerm", $"%{q}%");
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Categorie.Add(new Categoria
                {
                    //faccio il get dei campi del record restituito dalla query
                    Id= reader.GetInt32(0),
                    Nome= reader.GetString(1)
                });
            }
        }
    }


}