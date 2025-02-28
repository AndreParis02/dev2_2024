using Microsoft.AspNetCore.Mvc.RazorPages;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;
namespace _37_WebApp_SQLite.Pages.Prodotti;
public class PagedIndexModel : PageModel
{
    public PaginatedList<ProdottoViewModel> Prodotti{ get; set; }
    public int PageSize { get; set; } = 5;//numero di prodotti per pagina
    public void OnGet(int? pageIndex)
    {
        int currentPage = pageIndex ?? 1;
        //Recupera il numero totale di prodotti
        int totalCount = DbUtils.ExecuteScalar<int>("SELECT COUNT (*) FROM Prodotti");
        //calcola l'offset per la query
        int offset = (currentPage - 1) * PageSize;
        //Recupera i prodotti per la pagina corrente
        //in SQLite si usa LIMIT e OFFSET per la paginazione
        //limit = quanti elementi voglio
        //offset = da dove voglio partire
        //offset = (pagina corrente -1)* elementi per pagina
        //LIMIT 5 OFFSET 0 -> 5 elementi a partire dall'elemento 0
        string sql = $@"
            SELECT p.Id, p.Nome, p.Prezzo, c.Nome, f.Nome
            FROM Prodotti p
            LEFT JOIN Categorie c ON p.CategoriaId = c.Id
            LEFT JOIN Fornitori f ON p.FornitoreId = f.Id
            ORDER BY p.Id
            LIMIT {PageSize} OFFSET {offset}";


        List<ProdottoViewModel> items = DbUtils.ExecuteReader(sql,
        reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3),
                FornitoreNome = reader.IsDBNull(4) ? "Nessuno" : reader.GetString(4)
            }
        );
        //Crea l'oggetto paginato
        Prodotti = new PaginatedList<ProdottoViewModel>(items, totalCount, currentPage, PageSize);
    }
}
