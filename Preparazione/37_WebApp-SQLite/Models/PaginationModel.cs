namespace _37_WebApp_SQLite.Models;
public class PaginationModel
{
    public int PageIndex {get;set;}
    public int TotalPages {get;set;}
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
    //Funzione che,dato un numero di pagina, restitusice l'URL corrispondente.
    public Func <int, string> PageUrl {get;set;}

}