using Microsoft.AspNetCore.Mvc.RazorPages;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;
namespace _37_WebApp_SQLite.Pages.Fornitori;


public class FornitoriModel : PageModel
{


    public PaginatedList<Fornitore> Fornitori { get; set; }
     public int PageSize { get; set; } = 5;//numero di prodotti per pagina


    public void OnGet(int? pageIndex)
    {
        int currentPage = pageIndex ?? 1;
        //Recupera il numero totale di prodotti
        int totalCount = DbUtils.ExecuteScalar<int>("SELECT COUNT (*) FROM Fornitori");
        //calcola l'offset per la query
        int offset = (currentPage - 1) * PageSize;


        string sql = $@"
            SELECT Id, Nome FROM Fornitori
            ORDER BY Id
            LIMIT {PageSize} OFFSET {offset}";


            List<Fornitore> items = DbUtils.ExecuteReader(sql,
        reader => new Fornitore
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1)
            }
        );
                //Crea l'oggetto paginato
        Fornitori = new PaginatedList<Fornitore>(items, totalCount, currentPage, PageSize);


    }
}
