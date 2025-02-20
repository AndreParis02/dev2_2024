using Microsoft.AspNetCore.Mvc.RazorPages;
using _37_WebApp_SQLite.Models;
using _37_WebApp_SQLite.Utilities;
namespace _37_WebApp_SQLite.Pages.Categorie;


public class CategorieModel : PageModel
{


    public PaginatedList<Categoria> Categorie { get; set; }
     public int PageSize { get; set; } = 5;//numero di prodotti per pagina


    public void OnGet(int? pageIndex)
    {
        int currentPage = pageIndex ?? 1;
        //Recupera il numero totale di prodotti
        int totalCount = DbUtils.ExecuteScalar<int>("SELECT COUNT (*) FROM Categorie");
        //calcola l'offset per la query
        int offset = (currentPage - 1) * PageSize;


        string sql = $@"
            SELECT Id, Nome FROM Categorie
            ORDER BY Id
            LIMIT {PageSize} OFFSET {offset}";


            List<Categoria> items = DbUtils.ExecuteReader(sql,
        reader => new Categoria
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1)
            }
        );


                //Crea l'oggetto paginato
        Categorie = new PaginatedList<Categoria>(items, totalCount, currentPage, PageSize);


    }
}
