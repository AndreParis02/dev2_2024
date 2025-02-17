using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;

public class DashboardModel : PageModel
{

    public List<ProdottoViewModel> ProdottiPiuCostosi { get; set; } = new List<ProdottoViewModel>();
    public List<ProdottoViewModel> ProdottiRecenti { get; set; } = new List<ProdottoViewModel>();
    public List<ProdottoViewModel> ProdottiPerCategoria { get; set; } = new List<ProdottoViewModel>();

    public void OnGet()
    {


        try
        {
            //Utilizzo di DbUtils per leggere la lista dei prodotti
            ProdottiPiuCostosi = DbUtils.ExecuteReader(
                @"
                        SELECT p.Id, p.Nome, p.Prezzo, c.Nome AS CategoriaNome 
                        FROM Prodotti p
                        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                        ORDER BY p.Prezzo DESC
                        LIMIT 5
                    ",
                    reader => new ProdottoViewModel
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Prezzo = reader.GetDouble(2),
                        CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                    }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        try
        {
            //Utilizzo di DbUtils per leggere la lista dei prodotti
            ProdottiRecenti = DbUtils.ExecuteReader(
                @"
                        
                        SELECT p.Id, p.Nome, p.Prezzo, c.Nome AS CategoriaNome 
                        FROM Prodotti p
                        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                        ORDER BY p.Id DESC
                        LIMIT 5
                    ",
                    reader => new ProdottoViewModel
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Prezzo = reader.GetDouble(2),
                        CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                    }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        try
        {
            //Utilizzo di DbUtils per leggere la lista dei prodotti
            ProdottiPerCategoria = DbUtils.ExecuteReader(
                @"
                        SELECT p.Id, p.Nome, p.Prezzo, c.Nome AS CategoriaNome 
                        FROM Prodotti p
                        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                        WHERE c.Nome = 'Film'
                        LIMIT 5
                    ",
                    reader => new ProdottoViewModel
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Prezzo = reader.GetDouble(2),
                        CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                    }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }
}
