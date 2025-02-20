using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;
namespace _37_WebApp_SQLite.Pages.Fornitori;
public class SearchModel : PageModel
{
    //abbiamo bisogno di una proprieta pubblica
    public string SearchTerm {get; set;}
    public int pageIndex { get; set; } = 1;
    public PaginatedList<Fornitore> Fornitori {get; set;}
     public int PageSize { get; set; } = 5; // numero di Fornitore per pagina
    public void OnGet(string q, int? pageIndex)
    {
        //assegno la stringa di ricerca alla proprieta pubblica
        SearchTerm = q;
        int currentPage = pageIndex ?? 1;


        //calcola l'offset per la query
        int offset = (currentPage - 1) * PageSize;


        int totalCount = DbUtils.ExecuteScalar<int>(@"SELECT COUNT(*) FROM Fornitori WHERE Nome LIKE @searchTerm",
        cmd =>
        {
            cmd.Parameters.AddWithValue("@searchTerm", $"%{q}%");
        });


        //se la stringa di ricerca non è vuota
        if (!string.IsNullOrWhiteSpace(q))
        {
            string sql = $@"
            SELECT Id, Nome FROM Fornitori WHERE Nome LIKE @searchTerm
            ORDER BY Id
            LIMIT {PageSize} OFFSET {offset}";


            List<Fornitore> items = DbUtils.ExecuteReader(sql,
            reader => new Fornitore
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
            },
            cmd =>
        {
            cmd.Parameters.AddWithValue("@searchTerm", $"%{q}%");
        });




            //Crea l'oggetto paginato
             Fornitori = new PaginatedList<Fornitore>(items, totalCount, currentPage, PageSize);
        }
        else
        {
            Fornitori = new PaginatedList<Fornitore>(new List<Fornitore>(), 0, 1, PageSize);
        }
    }
}
