/*
|Cassa|Tipo di dato|Note|
|---|---|---|
|ID|int|viene generato in automatico con un progressivo|
|dipendente|Dipendente|
|acquisti|Purchases[]|
|scontrino_processato|Bool|di default e `false` e diventa `true` quando la cassa ha processato lo scontrino|
*/
public class Cassa 
{
    public int ID {get;set;}
    public Dipendente dipendente {get;set;}
    public List<Purchases> acquisti {get;set;}
    public bool scontrino_processato {get;set;}
}