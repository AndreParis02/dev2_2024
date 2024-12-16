/*
|Purchases|Tipo di dato|Note|
|---|---|---|
|ID|int|viene generato in automatico con un progressivo|
|cliente|Cliente||
|prodotti|Prodotto[]|viene inserito dal cliente|
|quantita|int|viene inserita dal cliente|
|data|Date|viene generato in automatico con la data corrente (quando il cliente completa l acquisto)|
|stato|Bool|lo stato di un acquisto di default e `in corso` e puo essere modificato dal cliente in `completato` o `annullato`|
*/

public class Acquisto
{
    public int ID {get;set;}
    public Cliente cliente {get;set;}
    public List<Prodotto> prodotti {get;set;}
    public int quantita {get;set;}
    public DateTime data {get;set;}
    public bool stato {get;set;}
}