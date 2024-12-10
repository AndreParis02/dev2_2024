using Newtonsoft.Json;

//comando per insallare il pacchetto Newtonsoft.Json
//dotnet add package Newtonsoft.Json
class Program
{
    static void Main(string[] args)
    {
        //Creare un oggetto di tipo ProdottoRepository per gestire il salvataggio e il caricamento dei dati
        ProdottoRepository repository = new ProdottoRepository();
        //Caricare i dati da file con il metodo CaricaProdotti della classe ProdottiRepository (repository)
        List<ProdottoAdvanced> prodotti = repository.CaricaProdotti();

        //Creare un oggetto di tipo ProdottoAdvancedManager per gestire i prodotti
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager();

        //Aggiungere i prodotti alla lista con il metodo AggiungiProdotto della classe ProdottoAdvancedManager (manager)
        manager.AggiungiProdotto(new ProdottoAdvanced { ID = 1, NomeProdotto = "Prodotto A", PrezzoProdotto = 10.50m, GiacenzaProdotto = 100 });
        manager.AggiungiProdotto(new ProdottoAdvanced { ID = 2, NomeProdotto = "Prodotto B", PrezzoProdotto = 20.75m, GiacenzaProdotto = 50 });

        //Visualizzare i prodotti con il metodo OttieniProdotti della classe ProdottoAdvancedManager (manager)
        Console.WriteLine("Prodotti:");
        foreach (var prodotto in manager.OttieniProdotti())
        {
            Console.WriteLine($"ID: {prodotto.ID}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }

        //Trova un prodotto per ID con il metodo TrovaProdotto della classe ProdottoAdvancedManager (manager)
        int idProdotto = 1;
        ProdottoAdvanced prodottoTrovato = manager.TrovaProdotto(idProdotto);
        if (prodottoTrovato != null)
        {
            Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.NomeProdotto}");
        }
        else
        {
            Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
        }

        //Aggiorna un prodotto con il metodo AggiornaProdotto della classe ProdottoAdvancedManager (manager)
        int idProdottoDaAggiornare = 2;
        ProdottoAdvanced nuovoProdotto = new ProdottoAdvanced { ID = 2, NomeProdotto = "Prodotto C", PrezzoProdotto = 30.25m, GiacenzaProdotto = 75 };
        manager.AggiornaProdotto(idProdottoDaAggiornare, nuovoProdotto);

        //Visualizzare i prodotti con il metodo OttieniProdotti della classe ProdottoAdvancedManager (manager)
        Console.WriteLine("Prodotti:");
        foreach (var prodotto in manager.OttieniProdotti())
        {
            Console.WriteLine($"ID: {prodotto.ID}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }

        //eliminare un prodotto con il metodo EliminaProdotto della classe ProdottoAdvancedManager (manager)
        int idProdottoDaEliminare = 1;
        manager.EliminaProdotto(idProdottoDaEliminare);

        //Visualizzare i prodotti con il metodo OttieniProdotti della classe ProdottoAdvancedManager (manager)
        Console.WriteLine("Prodotti:");
        foreach (var prodotto in manager.OttieniProdotti())
        {
            Console.WriteLine($"ID: {prodotto.ID}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }

        //salvare i prodotti su file con il metodo SalvaProdotti della classe ProdottiRepository (repository)
        repository.SalvaProdotti(manager.OttieniProdotti());
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
}

public class ProdottoAdvancedManager
{
    private List<ProdottoAdvanced> prodotti; //prodotti è private perchè non voglio che venga modificato dall'esterno

    public ProdottoAdvancedManager()
    {
        prodotti = new List<ProdottoAdvanced>(); //inizializzo la lista dei prodotti nel costruttore pubblico in modo che sia accessibile all'esterno

    }

    //metodo per aggiungere un prodotto alla lista
    public void AggiungiProdotto(ProdottoAdvanced prodotto)
    {
        prodotti.Add(prodotto);
    }

    //metodo per visualizzare la lista dei prodotti
    public List<ProdottoAdvanced> OttieniProdotti()
    {
        return prodotti;
    }

    //metodo per cercare un prodotto
    public ProdottoAdvanced TrovaProdotto(int id)
    {
        foreach (var prodotto in prodotti)
        {
            if (prodotto.ID == id)
            {
                return prodotto;
            }
        }
        return null;
    }

    //metodo per modificare un prodotto esistente
    public void AggiornaProdotto(int id, ProdottoAdvanced nuovoProdotto)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotto.NomeProdotto = nuovoProdotto.NomeProdotto;
            prodotto.PrezzoProdotto = nuovoProdotto.PrezzoProdotto;
            prodotto.GiacenzaProdotto = nuovoProdotto.GiacenzaProdotto;
        }
    }

    //metodo per eliminare il prodotto
    public void EliminaProdotto(int id)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotti.Remove(prodotto);
        }
    }
}

//La classe ProdottoRepository è una classe che si occupa di gestire la persistenza dei dati in modo centralizzato
//i vantaggi di questa classe sono:
//- centralizzazione della logica di accesso ai dati;
//- facilità di manutenzione
//- facilità di test
//- possibilità di cambiare il tipo di persistenza senza dover modificare il codice che utilizza la classe
//- possibilità di aggiungere logica di caching (memorizzazione temporanea dei dati) senza dover modificare il codice che utilizza la classe
public class ProdottoRepository
{
    //filePath è il percorso del file in cui memorizzare i dati ed ha il modificatore private
    //perche non voglio che venga modificato dall'esterno della classe prima di essere utilizzato

    private readonly string filePath = "prodotti.json"; //il percorso del file in cui memorizzare i dati

    //metodo per salvare i dati su file
    //accetta un parametro di tipo List<ProdottoAdvanced> che presenta la lista di prodotti da salvare

    public void SalvaProdotti(List<ProdottoAdvanced> prodotti)
    {
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
        Console.WriteLine($"Dati salvati in {filePath}:\n{jsonData}\n");
    }

    public List<ProdottoAdvanced> CaricaProdotti()
    {
        if (File.Exists(filePath))
        {
            string readJsonData = File.ReadAllText(filePath);
            List<ProdottoAdvanced> prodotti = JsonConvert.DeserializeObject<List<ProdottoAdvanced>>(readJsonData); //deserializzo i dati letti dal file
            Console.WriteLine("Dati caricati da file:");
            foreach (var prodotto in prodotti)
            {
                Console.WriteLine($"ID: {prodotto.ID}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
            }
            //restituidco la lista dei prodotti letti dal file in modo che possa essere utilizzata all'esterno della classe
            return prodotti;
        }
        else
        {
            Console.WriteLine("Nessun dato trovato. Inizializzare una nuova lista di prodotti.");
            return new List<ProdottoAdvanced>();
        }
    }
}



