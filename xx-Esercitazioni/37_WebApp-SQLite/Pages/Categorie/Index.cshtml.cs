using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;

namespace _37_WebApp_SQLite.Pages.Categorie;

public class CategorieModel : PageModel
{

    public List<Categoria> Categorie { get; set; } = new List<Categoria>();

    public void OnGet()
    {

        using var connection = DatabaseInitializer.GetConnection();


        connection.Open();

        var sql = @"
                        SELECT Id, Nome
                        FROM Categorie
                    ";


        using var command = new SQLiteCommand(sql, connection);


        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Categorie.Add(new Categoria
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1)
            });

        }
    }
}