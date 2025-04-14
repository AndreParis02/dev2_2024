using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; //in modo da usare SelectListItem
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;

namespace _37_WebApp_SQLite.Pages.Fornitori;
public class AggiungiModel : PageModel
{
   
    [BindProperty] //attributo bind proprety per collegare il modello al form
    public Fornitore Fornitore { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
    
     try
        {
            DbUtils.ExecuteNonQuery(
                "INSERT INTO Fornitori (Nome) VALUES ( @nome)",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@nome", Fornitore.Nome);

                }
            );
        }
        catch(Exception ex)
        {
            SimpleLogger.Log(ex);
            return Page();
        }
        return RedirectToPage("Index");
    }
}