/*
|Dipendente|Tipo di dato|Note|
|---|---|---|
|ID|Int|viene generato in automatico con un progressivo|
|username|String|viene assegnato dall admin|
|ruolo|String|viene assegnato dall admin e puo essere cassiere o magazziniere|
*/

public class Dipendente

{
    public int ID {get;set;}
    public String Username {get;set;}
    public Ruolo Ruolo {get;set;}
}
