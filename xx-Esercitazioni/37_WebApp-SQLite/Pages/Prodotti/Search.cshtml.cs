using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;
namespace _37_WebApp_SQLite.Pages.Prodotti;


public class SearchModel : PageModel
{
    //abbiamo bisogno di una proprieta pubblica
    public string SearchTerm { get; set; }


    public int pageIndex { get; set; } = 1;
    public PaginatedList<ProdottoViewModel>? Prodotti { get; set; }
    public int PageSize { get; set; } = 5; // numero di prodotti per pagina


    public void OnGet(string q, int? pageIndex)
    {
        //assegno la stringa di ricerca alla proprieta pubblica
        SearchTerm = q;
        int currentPage = pageIndex ?? 1;
        //Recupera il numero totale di prodotti


        //calcola l'offset per la query
        int offset = (currentPage - 1) * PageSize;


        int totalCount = DbUtils.ExecuteScalar<int>(@"SELECT COUNT(*) FROM Prodotti WHERE Nome LIKE @searchTerm",
        cmd =>
        {
            cmd.Parameters.AddWithValue("@searchTerm", $"%{q}%");
        });


        //se la stringa di ricerca non è vuota
        if (!string.IsNullOrWhiteSpace(q))
        {
            string sql = $@"
            SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id WHERE p.Nome LIKE @searchTerm
            ORDER BY p.Id
            LIMIT {PageSize} OFFSET {offset}";


            List<ProdottoViewModel> items = DbUtils.ExecuteReader(sql,
            reader => new ProdottoViewModel
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
            },
            cmd =>
        {
            cmd.Parameters.AddWithValue("@searchTerm", $"%{q}%");
        });




            //Crea l'oggetto paginato
             Prodotti = new PaginatedList<ProdottoViewModel>(items, totalCount, currentPage, PageSize);
        }
        else
        {
            Prodotti = new PaginatedList<ProdottoViewModel>(new List<ProdottoViewModel>(), 0, 1, PageSize);
        }
    }
}
