using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    public IEnumerable<Prodotto> Prodotti { get; set; }    //IEnumerable indica una sequenza di elementi
                                                           //che non supporta la modifica

    public string Ricerca { get; set; }
    public void OnGet(string Ricerca)
    {
        Prodotti = new List<Prodotto>
        {
            new Prodotto {Nome = "Cotechino", Prezzo = 100, Dettaglio = "Dettaglio1"},
            new Prodotto {Nome = "Coca Cola", Prezzo = 200, Dettaglio = "Dettaglio2"},
            new Prodotto {Nome = "Gatti", Prezzo = 300, Dettaglio = "Dettaglio3"}
        };

        //creo una lista di prodotti filtrati
        List<Prodotto> prodottiFiltrati = new List<Prodotto>();
        //aggiungo alla lista prodottiFiltrati solo i prodotti che contengono la stringa ricerca
        if (!string.IsNullOrEmpty(Ricerca))
        {
            foreach (var prodotto in Prodotti)
            {
                if (prodotto.Nome.Contains(Ricerca))
                {
                    prodottiFiltrati.Add(prodotto);
                }
            }
            Prodotti = prodottiFiltrati;
        }  
    }
}
