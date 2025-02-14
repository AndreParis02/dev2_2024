using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;
using _37_WebApp_SQLite.Models;

public class DashboardModel : PageModel
{

    public List<ProdottoViewModel> ProdottiPiuCostosi { get; set; } = new List<ProdottoViewModel>();
    public List<ProdottoViewModel> ProdottiRecenti { get; set; } = new List<ProdottoViewModel>();
    public List<ProdottoViewModel> ProdottiPerCategoria { get; set; } = new List<ProdottoViewModel>();

    public void OnGet()
    {
        using (var connection = DatabaseInitializer.GetConnection())
        {
            connection.Open();

            var sqlPiuCostosi = @"
                        SELECT p.Id, p.Nome, p.Prezzo, c.Nome AS CategoriaNome 
                        FROM Prodotti p
                        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                        ORDER BY p.Prezzo DESC
                        LIMIT 5
                    ";

            using (var command = new SQLiteCommand(sqlPiuCostosi, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProdottiPiuCostosi.Add(new ProdottoViewModel
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Prezzo = reader.GetDouble(2),
                            CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                        });
                    }
                }
            }
        }
        using (var connection = DatabaseInitializer.GetConnection())
        {
            connection.Open();

            var sqlRecenti = @"
                        SELECT p.Id, p.Nome, p.Prezzo, c.Nome AS CategoriaNome 
                        FROM Prodotti p
                        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                        ORDER BY p.Id DESC
                        LIMIT 5
                    ";


            using (var command = new SQLiteCommand(sqlRecenti, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProdottiRecenti.Add(new ProdottoViewModel
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Prezzo = reader.GetDouble(2),
                            CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                        });
                    }
                }
            }
        }
        using (var connection = DatabaseInitializer.GetConnection())
        {
            connection.Open();

            var sqlPerCategoria = @"
                        SELECT p.Id, p.Nome, p.Prezzo, c.Nome AS CategoriaNome 
                        FROM Prodotti p
                        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
                        WHERE c.Nome = 'Giochi'
                        LIMIT 5
                    ";

            using var command = new SQLiteCommand(sqlPerCategoria, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                ProdottiPerCategoria.Add(new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                });
            }
        }

    }
}
