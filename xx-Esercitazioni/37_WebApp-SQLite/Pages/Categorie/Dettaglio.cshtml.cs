
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;

namespace _37_WebApp_SQLite.Pages.Categorie;

public class DettaglioModel : PageModel
{
    public Categoria Categoria { get; set; }

    public IActionResult OnGet(int id)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        
       
        var sql = @"SELECT Id, Nome FROM  Categorie WHERE Id = @id";

        using var command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        using var reader = command.ExecuteReader();


        if (reader.Read())
        {
            Categoria = new Categoria
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
            };
        }
        else
        {
            return NotFound(); // Se non trova il prodotto, ritorna NotFound
        }

        return Page();
    }
    
}