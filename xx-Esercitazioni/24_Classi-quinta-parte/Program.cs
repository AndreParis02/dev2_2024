using Newtonsoft.Json;

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

        //Menu interattivo per eseguire operazioni CRUD sui prodotti

        //variabile per controllare se il programma deve continuare o uscire
        bool continua = true;

        //il ciclo while continua finchè le variabile continua è true
        while (continua)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Visualizza Prodotti");
            Console.WriteLine("2. Aggiungi Prodotto");
            Console.WriteLine("3. Trova Prodotto per ID");
            Console.WriteLine("4. Aggiorna Prodotto");
            Console.WriteLine("5. Elimina Prodotto");
            Console.WriteLine("0. Esci");

            //acquisire l'iput dell'utente
            Console.Write("\nScelta: ");
            string scelta = Console.ReadLine();

            //switch-case per gestire le scelte dell'utente che usa scelta come variabile di controllo
            switch (scelta)
            {
                case "1":
                    Console.WriteLine("\nProdotti: ");

                    //visualizzare i prodotti con il metodo OttieniProdotti dalla classe ProdottoAdvancedManager (manager)
                    foreach (var prodotto in manager.OttieniProdotti())
                    {
                        Console.WriteLine($"ID: {prodotto.ID}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
                    }
                    break;
                case "2":
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Prezzo: ");
                    decimal prezzo = decimal.Parse(Console.ReadLine());
                    Console.Write("Giacenza: ");
                    int giacenza = int.Parse(Console.ReadLine());
                    manager.AggiungiProdotto(new ProdottoAdvanced { ID = id, NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza });
                    break;
                case "3":
                    Console.Write("ID: ");
                    int idProdotto = int.Parse(Console.ReadLine());
                    ProdottoAdvanced prodottoTrovato = manager.TrovaProdotto(idProdotto);
                    if(prodottoTrovato != null)
                    {
                        Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.NomeProdotto}");
                    }
                    else
                    {
                        Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
                    }
                    break;
                case "4":

                    break;
                case "5":

                    break;
                case "0":
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
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

public class ProdottoRepository
{

    private readonly string filePath = "prodotti.json";
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
            return prodotti;
        }
        else
        {
            Console.WriteLine("Nessun dato trovato. Inizializzare una nuova lista di prodotti.");
            return new List<ProdottoAdvanced>();
        }
    }
}



