using Newtonsoft.Json;
// comando per installare la libreria Newtonsoft.Json
// dotnet add package Newtonsoft.Json
class Program
{
    static void Main(string[] args)
    {
        // Creare un oggetto di tipo ProdottoRepository per gestire il salvataggio e il caricamento dei dati
        CategoriaRepository repository = new CategoriaRepository();

        // Caricare i dati da file con il metodo CaricaProdotti della classe ProdottoRepository (repository)
        List<Categoria> categorie = repository.CaricaCategorie();

        // Creare un oggetto di tipo ProdottoManager per gestire i prodotti
        CategoriaManager manager = new CategoriaManager(categorie);

        // Menu interattivo per eseguire operazioni CRUD sui prodotti

        // variabile per controllare se il programma deve continuare o uscire
        bool continua = true;

        // il ciclo while continua finché la variabile continua è true
        while (continua)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Visualizza Categorie");
            Console.WriteLine("2. Aggiungi Categoria");
            Console.WriteLine("3. Trova Categoria per ID");
            Console.WriteLine("4. Aggiorna Categoria");
            Console.WriteLine("5. Elimina Categoria");
            Console.WriteLine("6. Salva ed Esci");

            // acquisire l'input dell'utente
            // Console.Write("\nScelta: ");
            // string scelta = Console.ReadLine();
            // string scelta acquisita mediante il metodo LeggiInteri della classe InputManager
            string scelta = InputManager.LeggiIntero("\nScelta", 1, 6).ToString();
            // pulisco la console
            Console.Clear();

            // switch-case per gestire le scelte dell'utente che usa scelta come variabile di controllo
            switch (scelta)
            {
                case "1":
                    Console.WriteLine("\nCategoria:");
                    manager.StampaCategorieIncolonnati();
                    break;
                case "2":
                    string nome = InputManager.LeggiStringa("\nNome: ");
                    manager.AggiungiCategoria(new Categoria { Nome = nome});
                    break;
                case "3":
                    int idCategoria = InputManager.LeggiIntero("\nID: ");
                    Categoria CategoriaTrovato = manager.TrovaCategoria(idCategoria);
                    if (CategoriaTrovato != null)
                    {
                        Console.WriteLine($"\nCategoria trovato per ID {idCategoria}: {CategoriaTrovato.Nome}");
                    }
                    else
                    {
                        Console.WriteLine($"\nCategoria non trovato per ID {idCategoria}");
                    }
                    break;
                case "4":
                    int idCategoriaDaAggiornare = InputManager.LeggiIntero("\nID: ");
                    string nomeNuovo = InputManager.LeggiStringa("\nNome: ");
                    manager.AggiornaCategoria(idCategoriaDaAggiornare, new Categoria { Nome = nomeNuovo});
                    break;
                case "5":
                    int idCategoriaDaEliminare = InputManager.LeggiIntero("\nID: ");
                    manager.EliminaCategoria(idCategoriaDaEliminare);
                    break;
                case "6":
                    repository.SalvaCategorie(manager.OttieniCategorie());
                    continua = false; // imposto la variabile continua a false per uscire dal ciclo while
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprovare.");
                    break;
            }
        }
    }
}