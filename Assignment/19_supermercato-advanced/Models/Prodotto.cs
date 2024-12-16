/*
|Prodotto|Tipo di dato|Note|
|---|---|---|
|ID|int|viene generato in automatico con un progressivo|
|nome|String|viene inserito dal magazziniere|
|prezzo|double|viene inserito dal magazziniere|
|giacenza|int|viene inserito dal magazziniere|
|categoria|string|viene inserito dal magazziniere|
*/
public class Prodotto

{
     public int ID {get;set;}
    public string Nome {get;set;}
    public decimal Prezzo {get;set;}
    public int Giacenza {get;set;}
    public Categoria categoria{get;set;}
}