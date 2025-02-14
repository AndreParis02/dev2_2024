using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; //in modo da usare SelectListItem
using System.Data.SQLite;

namespace _37_WebApp_SQLite.Pages.Categorie;
public class AggiungiModel : PageModel
{
   
    [BindProperty] //attributo bind proprety per collegare il modello al form
    public Categoria Categoria { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
    
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

       
        var sql = "INSERT INTO Categorie (Nome) VALUES ( @nome)";
       

        using var command = new SQLiteCommand(sql,connection);
        command.Parameters.AddWithValue("@nome",Categoria.Nome);


        command.ExecuteNonQuery();

        return RedirectToPage("Index");
    }
}