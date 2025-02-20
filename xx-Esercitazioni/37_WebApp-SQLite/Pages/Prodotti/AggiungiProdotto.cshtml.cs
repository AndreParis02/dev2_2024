using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; //in modo da usare SelectListItem
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;

namespace _37_WebApp_SQLite.Pages.Prodotti;

public class AggiungiProdottoModel : PageModel
{

    [BindProperty] //attributo bind proprety per collegare il modello al form
    public Prodotto Prodotto { get; set; }

    //creo una lista di select list item per contenere le categorie
    //select list item è un oggetto che rappresenta un elemento di una select list
    public List<SelectListItem> CategorieSelectList { get; set; } = new List<SelectListItem>();
    public List<SelectListItem> FornitoriSelectList {get; set;} = new List<SelectListItem>();

    public void OnGet()
    {
        CaricaCategorie();
        CaricaFornitori();
    }

    public IActionResult OnPost()
    {   
        //Controlliamo se il modello è valid cioè se o dato inseriti dall'utente rispettano le regole di validazione
        //se il modello non è valido ritorno la pagina con gli errori
        if (!ModelState.IsValid)
        {
            CaricaCategorie(); //carico le categorie se no quando si carica viene caricato senza categorie
            CaricaFornitori();
            //page è un metodo di page model che restituisce un oggetto page result che rappresenta la pagina nella quale siamo
            return Page();//se il modello non è valido ritorno la pagina
        }

        try
        {
            DbUtils.ExecuteNonQuery(
                "INSERT INTO Prodotti (Nome, Prezzo, CategoriaId, FornitoreId) VALUES (@nome, @prezzo, @categoriaId, @fornitore)",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@nome", Prodotto.Nome);
                    cmd.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
                    cmd.Parameters.AddWithValue("@categoriaId", Prodotto.IdCategoria);
                    cmd.Parameters.AddWithValue("@fornitore", Prodotto.IdFornitore);
                }
            );
        }
        catch(Exception ex)
        {
            SimpleLogger.Log(ex);
            CaricaCategorie();
            return Page();
        }
        return RedirectToPage("PagedIndex");
    }

    //metodo per caricare le categorie
    private void CaricaCategorie()
    {
        try
        {
            //Utilizzo di DbUtils per leggere la lista dei prodotti
            CategorieSelectList = DbUtils.ExecuteReader(
                "SELECT Id, Nome FROM Categorie",
                reader => new SelectListItem
                {
                    Value = reader.GetInt32(0).ToString(), 
                    Text = reader.GetString(1)
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }

     private void CaricaFornitori()
    {
        try
        {
            FornitoriSelectList = DbUtils.ExecuteReader(
                "SELECT Id, Nome FROM Fornitori",
                reader => new SelectListItem
                {
                    Value = reader.GetInt32(0).ToString(),
                    Text = reader.GetString(1)
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }
}