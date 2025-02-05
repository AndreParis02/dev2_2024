using System;
using System.Collections.Generic;
using _36_WebApp_Prodotti.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;
    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }
    public IEnumerable<Prodotto> Prodotti { get; set; }

      public int numeroPagine {get;set;} //aggiunta di una proprietà per il numero di pagine

    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex) //aggiunda di parametri per i filtri
    {
        //Lista iniziale di tutti i prodotti
        var allProdotti = new List<Prodotto>
        {
            new Prodotto {Id = 1, Nome = "Vinile Linkin Park", Prezzo = 100, Descrizione = "Descrizione 1", Dettaglio = "Dettagli", Immagine = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1CHROzbfvlSFM3x8PAyIvjsxERDp1OnfoEQ&s"},
            new Prodotto {Id = 2, Nome = "Vinile Green Day", Prezzo = 200, Descrizione = "Descrizione 2", Dettaglio = "Dettagli", Immagine = "https://www.lafeltrinelli.it/images/0093624862734_0_1_536_0_75.jpg"},
            new Prodotto {Id = 3, Nome = "Vinile Gorillaz", Prezzo = 300, Descrizione = "Descrizione 3", Dettaglio = "Dettagli", Immagine = "https://www.vinylmeplease.com/cdn/shop/products/demon_days_vinyl.jpg?v=1564066231&width=1500"},
            new Prodotto {Id = 4, Nome = "Vinile Guns N'Roses", Prezzo = 400, Descrizione = "Descrizione 4", Dettaglio = "Dettagli", Immagine = "https://www.impericon.com/cdn/shop/files/20210625_guns_n_roses_appetite_for_destruction_lp_lg.jpg?v=1731626436"},
            new Prodotto {Id = 5, Nome = "Vinile AC/DC", Prezzo = 500, Descrizione = "Descrizione 5", Dettaglio = "Dettagli", Immagine = "https://i.ebayimg.com/images/g/7q4AAOSwm~Nl1M0J/s-l400.jpg"},
            new Prodotto {Id = 6, Nome = "Vinile Metallica", Prezzo = 600, Descrizione = "Descrizione 6", Dettaglio = "Dettagli", Immagine = "https://m.media-amazon.com/images/I/61Y9Pvb7IaL._UF1000,1000_QL80_.jpg"},
            new Prodotto {Id = 7, Nome = "Vinile Arctic Monkeys", Prezzo = 700, Descrizione = "Descrizione 7", Dettaglio = "Dettagli", Immagine = "https://i.ebayimg.com/images/g/UY0AAOSwJYZl-H6y/s-l1200.jpg"},
            new Prodotto {Id = 8, Nome = "Vinile Falling in reverse", Prezzo = 220, Descrizione = "Descrizione 8", Dettaglio = "Dettagli", Immagine = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQm7TVBOmPD6NkEpJki99K4qJhJ7fNcbPJWNQ&s"},
            new Prodotto {Id = 9, Nome = "Vinile Pink floyd", Prezzo = 800, Descrizione = "Descrizione 9", Dettaglio = "Dettagli", Immagine = "https://ss-pics.s3.eu-west-1.amazonaws.com/files/1044511/page-original-dark.jpg?1583395453"},
        };
        _logger.LogInformation("Prodotti Caricati");

        //inizializziamo la lista filtrata
        var prodottiFiltrati = new List<Prodotto>();

        //iteriamo su tutti i prodotti
        foreach(var prodotto in allProdotti)
        {
            bool aggiungi = true;

            //applichiamo il filtro per minPrezzo se presente
            if(minPrezzo.HasValue)
            {
                if(prodotto.Prezzo < minPrezzo.Value)
                {
                    aggiungi = false;
                }
            }

            //applichiamo il filtro per maxPrezzo se presente
            if(maxPrezzo.HasValue)
            {
                if(prodotto.Prezzo > maxPrezzo.Value)
                {
                    aggiungi = false;
                }
            }

            //se il prodotto soddisfa tutti i criteri, lo aggiungiamo alla lista flitrata
            if(aggiungi)
            {
                prodottiFiltrati.Add(prodotto);
            }
        }
        //assegnamo i prodotti filtrati alla proprietà Prodotti
        Prodotti = prodottiFiltrati;

      

    numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 6.0); 
 
    Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 6).Take(6);
    }

 


}