using System.Dynamic;
using Newtonsoft.Json;

//comando per insallare il pacchetto Newtonsoft.Json
//dotnet add package Newtonsoft.Json
class Program
{
    static void Main(string[] args)
    {
        List<Prodotto> prodotti = new List<Prodotto>
        {
            //10.50m la m sta per decimal (tipo di dato) e indica che il valore è un decimale (numero con la virgola)
            new Prodotto {ID = 1, NomeProdotto = "Prodotto A", PrezzoProdotto = 10.50m, GiacenzaProdotto = 100, DescrizioneProdotto = "prova descrizone prodotto A"},
            new Prodotto {ID = 2, NomeProdotto = "Prodotto B", PrezzoProdotto = 20.75m, GiacenzaProdotto = 50, DescrizioneProdotto = "prova descrizone prodotto B"}
        };

        //Serializzare i dati in un file JSON
        string filePath = "prodotti.json";
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);

        Console.WriteLine($"Dati serializzati e salvati in {filePath}:\n{jsonData}\n");

        //Deserializzare i dati dal file JSON
        string readJsonData = File.ReadAllText(filePath);
        List<Prodotto> prodottiDeserializzati = JsonConvert.DeserializeObject<List<Prodotto>>(readJsonData);

        Console.WriteLine("Dati deserializzati:");
        foreach (var prodotto in prodottiDeserializzati)
        {
            Console.WriteLine($"ID: {prodotto.ID}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}, Descrizione: {prodotto.DescrizioneProdotto}");
        }
    }
}

//il modificatore public significa che la classe è accessibile da qualsiasi codice all'interno dell'applicazione
//gli altri tipi di accesso sono private, protected e internal
//La classe prodotto continene 4 proprietà: ID, NomeProdotto, PrezzoProdotto e GiacenzaProdotto
//Le proprietà sono definite con il modificatore di acesso public, quindi sono accessibili da qualsiasi codice all'interno dell'applicazione
//Le prorpietà sono definite con il modificatore set, quindi possono essere scritte da qualsiasi codice all'interno dell'applicazione
//Le prorpietà sono definite con il modificatore get, quindi possono essere lette da qualsiasi codice all'interno dell'applicazione

//esempio di classe pubblica
public class Prodotto
{
    public int ID { get; set; }
    public string NomeProdotto { get; set; }
    public decimal PrezzoProdotto { get; set; }
    public int GiacenzaProdotto { get; set; }
    public string DescrizioneProdotto { get; set; }
}
//esempio di classe con proprietà privata
public class ProdottoAdvanced
{
    //definisco una variabile privata ID
    //La definisco privata in modo che non possa essere modificata direttamente dall'esterno della classe
    //cosi solo la classe ProdottoAdvanced può accedere e modificare la variablie ID
    private int id; //campo privato

    //definisco una proprietà pubblica ID in modo che possa essere scritta dall'esterno della classe
    //il vantaggio di utilizzare una proprietà è che posso controllare l'accesso alla variabile privata ID e applicare delle regole

    public int ID
    {
        get { return id; } //restituisce il valore della variabile privata id
        //set { id = value; } // imposta il valore della variabile provata id con il valore passato come argomento
        //implemento la logica di validazione per il valore passato come argomento
        //se il valore passato come argomento è minore o uguale a zero, sollevo un'eccezione
        //l'eccezione interrompe l'esecuzione del programma e mostra un messaggio di errore
        //l'eccezione può essere catturata e gestita da un blocco try-catch
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il valore dell'ID deve essere maggiore di zero.");
            }
            id = value; // imposta il valore della variabile privata id con il valore passato come argomento
        }
    }

    private string nomeProdotto;

    public string NomeProdotto
    {
        get {return nomeProdotto;}
        set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("il nome del prodotto non può essere vuoto.");
            }
        }
    }
    private decimal prezzoProdotto;
    public decimal PrezzoProdotto  
    {
        get {return prezzoProdotto;}
        set
        {   
            if(value <= 0)
            {
                throw new ArgumentException("Il prezzo deve essere maggiore di zero.");
            }
        }
    }

    private int giacenzaProdotto; 

    public int GiacenzaProdotto
    {
        get{ return giacenzaProdotto;}
        set{ giacenzaProdotto = value;}
    }
    private string descrizioneProdotto;
    public string DescrizioneProdotto
    {
        get {return descrizioneProdotto;}
        set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("La descrizione del prodotto non può essere vuota.");
            }
        }
    }
}