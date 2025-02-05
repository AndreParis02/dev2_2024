using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public class ProdottoDettaglioModel :PageModel
{
    private readonly ILogger<ProdottoDettaglioModel> _logger;

    public ProdottoDettaglioModel(ILogger<ProdottoDettaglioModel> logger)
    {
        _logger = logger;
    }
    public Prodotto Prodotto {get;set;}
    public void OnGet(int id, string nome, decimal prezzo, string descrizione, string dettaglio, string immagine)
    {
        Prodotto = new Prodotto{Id = id, Nome = nome, Prezzo = prezzo, Descrizione = descrizione, Dettaglio = dettaglio, Immagine = immagine};
         _logger.LogInformation($"Dettaglio {Prodotto.Nome} Caricato");
       //non è necessario mettere var perchè il tipo à gia predefinito in prodotto
    }
}