using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;
using System.ComponentModel.Design;

public class DashboardModel : PageModel
{

    public List<ProdottoViewModel> ProdottiPiuCostosi { get; set; } = new List<ProdottoViewModel>();
    public List<ProdottoViewModel> ProdottiRecenti { get; set; } = new List<ProdottoViewModel>();
    public List<ProdottoViewModel> ProdottiPerCategoria { get; set; } = new List<ProdottoViewModel>();
    public List<ProdottoViewModel> ProdottiPerFornitore {get;set;} = new List<ProdottoViewModel>();
    public int TotProd;

    public void OnGet()
    {


        try
        {
            //Utilizzo di DbUtils per leggere la lista dei prodotti
            ProdottiPiuCostosi = DbUtils.ExecuteReader(
                @"
                        SELECT p.Id, p.Nome, p.Prezzo, c.Nome, f.Nome  
                        FROM Prodotti p
                        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                        LEFT JOIN Fornitori f ON p.FornitoreId = f.Id
                        ORDER BY p.Prezzo DESC
                        LIMIT 5
                    ",
                    reader => new ProdottoViewModel
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Prezzo = reader.GetDouble(2),
                        CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3),
                        FornitoreNome = reader.IsDBNull(4) ? "Nessuno" : reader.GetString(4)
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
                        
                        SELECT p.Id, p.Nome, p.Prezzo,c.Nome, f.Nome  
                        FROM Prodotti p
                        LEFT JOIN Fornitori f ON p.FornitoreId = f.Id
                        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                        ORDER BY p.Id DESC
                        LIMIT 5
                    ",
                    reader => new ProdottoViewModel
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Prezzo = reader.GetDouble(2),
                        CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3),
                        FornitoreNome = reader.IsDBNull(4) ? "Nessuno" : reader.GetString(4)
                    }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        try
        {
            TotProd = DbUtils.ExecuteScalar<int>("SELECT COUNT (*) FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id WHERE c.Nome = 'Giochi'");
            
        }
        catch(Exception ex)
        {
            SimpleLogger.Log(ex);
        }


        try
        {
            //Utilizzo di DbUtils per leggere la lista dei prodotti
            ProdottiPerCategoria = DbUtils.ExecuteReader(
                @"
                        SELECT p.Id, p.Nome, p.Prezzo,c.Nome  
                        FROM Prodotti p
                        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                        WHERE c.Nome = 'Giochi'
                        LIMIT @TotProd
                    ",
                    reader => new ProdottoViewModel
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Prezzo = reader.GetDouble(2),
                        CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)

                    },
                    cmd=>
                    {
                        cmd.Parameters.AddWithValue("@TotProd",TotProd);
                    }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

         try
        {
            TotProd = DbUtils.ExecuteScalar<int>("SELECT COUNT (*) FROM Prodotti p LEFT JOIN Fornitori f ON p.FornitoreId = f.Id WHERE f.Nome = 'Verdi'");
            
        }
        catch(Exception ex)
        {
            SimpleLogger.Log(ex);
        }


        try
        {
            //Utilizzo di DbUtils per leggere la lista dei prodotti
            ProdottiPerFornitore = DbUtils.ExecuteReader(
                @"
                        SELECT p.Id, p.Nome, p.Prezzo, f.Nome  
                        FROM Prodotti p
                        LEFT JOIN Fornitori f ON p.FornitoreId = f.Id
                        WHERE f.Nome = 'Verdi'
                        LIMIT @TotProd
                    ",
                    reader => new ProdottoViewModel
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Prezzo = reader.GetDouble(2),
                        FornitoreNome = reader.IsDBNull(3) ? "Nessuno" : reader.GetString(3)
                    },
                    cmd=>
                    {
                        cmd.Parameters.AddWithValue("@TotProd",TotProd);
                    }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }
}
