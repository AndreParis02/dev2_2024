using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        List<ProdottoAdvanced> prodotti = new List<ProdottoAdvanced>
        {
            new ProdottoAdvanced {ID = 1, NomeProdotto = "Prodotto A", PrezzoProdotto = 10.50m, GiacenzaProdotto = 100, DescrizioneProdotto = "prova descrizone prodotto A"},
            new ProdottoAdvanced {ID = 2, NomeProdotto = "Prodotto B", PrezzoProdotto = 20.75m, GiacenzaProdotto = 50, DescrizioneProdotto = "prova descrizone prodotto B"}
        };

        //Serializzare i dati in un file JSON
        string filePath = "prodotti.json";
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);

        Console.WriteLine($"Dati serializzati e salvati in {filePath}:\n{jsonData}\n");

        //Deserializzare i dati dal file JSON
        string readJsonData = File.ReadAllText(filePath);
        List<ProdottoAdvanced> prodottiDeserializzati = JsonConvert.DeserializeObject<List<ProdottoAdvanced>>(readJsonData);

        Console.WriteLine("Dati deserializzati:");
        foreach (var prodotto in prodottiDeserializzati)
        {
            Console.WriteLine($"ID: {prodotto.ID}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}, Descrizione: {prodotto.DescrizioneProdotto}");
        }

        //testare l'eccezione per l'id
        try
        {
            ProdottoAdvanced prodotto = new ProdottoAdvanced();
            prodotto.ID= 0;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }

        //testare l'eccezione per il nome
        try
        {
            ProdottoAdvanced prodotto = new ProdottoAdvanced();
            prodotto.NomeProdotto= "";
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }

        //testare l'eccezione per il prezzo
        try
        {
            ProdottoAdvanced prodotto = new ProdottoAdvanced();
            prodotto.PrezzoProdotto= 0;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }

        //testare l'eccezione per la descrizione
        try
        {
            ProdottoAdvanced prodotto = new ProdottoAdvanced();
            prodotto.DescrizioneProdotto= "";
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }
    }
}

public class ProdottoAdvanced
{
    private int id;
    public int ID
    {
        get { return id; }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il valore dell'ID deve essere maggiore di zero.");
            }
            id = value;
        }
    }

    private string nomeProdotto;

    public string NomeProdotto
    {
        get { return nomeProdotto; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Il nome del prodotto non può essere vuoto.");
            }
            nomeProdotto = value;
        }
    }
    private decimal prezzoProdotto;
    public decimal PrezzoProdotto
    {
        get { return prezzoProdotto; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il prezzo deve essere maggiore di zero.");
            }
            prezzoProdotto = value;
        }
    }

    private int giacenzaProdotto;

    public int GiacenzaProdotto
    {
        get { return giacenzaProdotto; }
        set { giacenzaProdotto = value; }
    }
    private string descrizioneProdotto;
    public string DescrizioneProdotto
    {
        get { return descrizioneProdotto; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("La descrizione del prodotto non può essere vuota.");
            }
            descrizioneProdotto = value;
        }
    }
}
