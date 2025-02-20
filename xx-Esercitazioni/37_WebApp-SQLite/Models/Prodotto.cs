namespace _37_WebApp_SQLite.Models;
public class Prodotto
{
    public int Id {get;set;}
    public string Nome {get;set;}
    public double Prezzo {get;set;}
    public int IdCategoria {get;set;}
    public int IdFornitore {get;set;}
}