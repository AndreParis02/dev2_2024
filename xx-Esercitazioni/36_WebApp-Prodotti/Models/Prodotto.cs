using Microsoft.AspNetCore.SignalR;

public class Prodotto
{
    public int Id {get;set;}
    public string Nome {get;set;}
    public decimal Prezzo {get;set;}
    public string Dettaglio {get;set;}
    public int Quantita {get;set;}
    public DateTime Data{get;set;}
    public string Categoria {get;set;}
    public string Immagine {get;set;}
}