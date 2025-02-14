using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; //in modo da usare SelectListItem
using System.Data.SqlClient;
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;

namespace _37_WebApp_SQLite.Pages.Prodotti;
public class EliminaModel : PageModel
{
    public ProdottoViewModel Prodotto { get; set; }
    public IActionResult OnGet(int id)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        var sql = @"Select p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p 
                    LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                    WHERE p.Id = @id";
                    
        using var command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            Prodotto = new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
            };
        }
        else
        {
            return NotFound();
        }
        return Page();
    }
    //uso l'id del prodotto nell'OnPost in modo da eliminare il prodotto con l'id passato come parametro
    public IActionResult OnPost(int id)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        var sql = "DELETE FROM Prodotti WHERE Id = @id";
        using var command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        command.ExecuteNonQuery();
        return RedirectToPage("Index");
    }
}