using System;
using System.Collections.Generic;
using _36_WebApp_Prodotti.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;
    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
        _logger.LogInformation("Prodotti Caricati");
    }
    public IEnumerable<Prodotto> Prodotti { get; set; }

    public int numeroPagine {get;set;} 

    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex) //aggiunda di parametri per i filtri
    {
        //Lista iniziale di tutti i prodotti
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var allProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

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