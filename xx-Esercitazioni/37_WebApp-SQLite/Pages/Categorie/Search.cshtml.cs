using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;
namespace _37_WebApp_SQLite.Pages.Categorie;
public class SearchModel : PageModel
{
    //abbiamo bisogno di una proprieta pubblica
    public string SearchTerm {get; set;}
    public int pageIndex { get; set; } = 1;
    public PaginatedList<Categoria> Categorie {get; set;}
     public int PageSize { get; set; } = 5; // numero di Categoria per pagina
    public void OnGet(string q, int? pageIndex)
    {
        //assegno la stringa di ricerca alla proprieta pubblica
        SearchTerm = q;
        int currentPage = pageIndex ?? 1;


        //calcola l'offset per la query
        int offset = (currentPage - 1) * PageSize;


        int totalCount = DbUtils.ExecuteScalar<int>(@"SELECT COUNT(*) FROM Categorie WHERE Nome LIKE @searchTerm",
        cmd =>
        {
            cmd.Parameters.AddWithValue("@searchTerm", $"%{q}%");
        });


        //se la stringa di ricerca non è vuota
        if (!string.IsNullOrWhiteSpace(q))
        {
            string sql = $@"
            SELECT Id, Nome FROM Categorie WHERE Nome LIKE @searchTerm
            ORDER BY Id
            LIMIT {PageSize} OFFSET {offset}";


            List<Categoria> items = DbUtils.ExecuteReader(sql,
            reader => new Categoria
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
            },
            cmd =>
        {
            cmd.Parameters.AddWithValue("@searchTerm", $"%{q}%");
        });




            //Crea l'oggetto paginato
             Categorie = new PaginatedList<Categoria>(items, totalCount, currentPage, PageSize);
        }
        else
        {
            Categorie = new PaginatedList<Categoria>(new List<Categoria>(), 0, 1, PageSize);
        }
    }
}
