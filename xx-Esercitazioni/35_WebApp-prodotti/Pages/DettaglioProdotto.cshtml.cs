using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class DettaglioProdottoModel : PageModel
{
    private readonly ILogger<DettaglioProdottoModel> _logger;

    public DettaglioProdottoModel(ILogger<DettaglioProdottoModel> logger)
    {
        _logger = logger;
    }

    public Prodotto Prodotto {get;set;}   

    // metodo passando l'intero prodotto
    public void OnGet(Prodotto prodotto)
    {
        Prodotto = prodotto;
    }

    // metodo passando i campi necessari 
    /*public void OnGet(string nome,decimal prezzo,string dettaglio)
    {
        Prodotto = new Prodotto {Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio}; // var non è necessario in quanto il tipo è gia specificato nel metodo
    }
    */
    
    
}
