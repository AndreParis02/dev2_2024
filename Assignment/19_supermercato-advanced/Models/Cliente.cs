/*
|Cliente|Tipo di dato|Note|
|---|---|--|
|ID|int|viene generato in automatico con un progressivo|
|username|String|ognuno decide come vuole farlo|
|carrello|Prodotto[]||
|storico_acquisti|Purchases[]|viene popolato al termine di ogni acquisto|
|percentuale_sconto|int|viene incrementata a seconda del valore dello storico degli acquisti|
|credito|double|
*/

public class Cliente
{
    public int ID {get; set;}
    public String Username {get;set;}
    public List<Prodotto> Carrello {get;set;}
    public List<Acquisto> StoricoAcquisti {get;set;}
    public decimal Credito {get;set;}
}