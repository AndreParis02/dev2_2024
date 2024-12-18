using System.Dynamic;
using Newtonsoft.Json;
// comando per installare la libreria Newtonsoft.Json
// dotnet add package Newtonsoft.Json
class Program
{
    static void Main(string[] args)
    {
        // Creare un oggetto di tipo Repository per gestire il salvataggio e il caricamento dei dati
        ProdottoRepository repositoryProdotto = new ProdottoRepository();
        ClienteRepository repositoryCliente = new ClienteRepository();
        CategoriaRepository repositoryCategoria = new CategoriaRepository();
        DipendenteRepository repositoryDipendente = new DipendenteRepository();
        AcquistoRepository repositoryAcquisto = new AcquistoRepository();

        // Caricare i dati da file con il metodo Carica della classe Repository (repository)
        List<Prodotto> prodotti = repositoryProdotto.CaricaProdotti();
        List<Cliente> clienti = repositoryCliente.CaricaClienti();
        List<Categoria> categorie = repositoryCategoria.CaricaCategorie();
        List<Dipendente> dipendenti = repositoryDipendente.CaricaDipendenti();
        List<Acquisto> acquisti = repositoryAcquisto.CaricaAcquisti();

        // Creare un oggetto di tipo Manager
        ProdottoManager managerProdotto = new ProdottoManager(prodotti);
        ClienteManager managerCliente = new ClienteManager(clienti);
        CategoriaManager managerCategoria = new CategoriaManager(categorie);
        DipendenteManager managerDipendente = new DipendenteManager(dipendenti);
        AcquistoManager managerAcquisto = new AcquistoManager(acquisti);


        // Menu interattivo per eseguire operazioni CRUD sui prodotti

        // variabile per controllare se il programma deve continuare o uscire
        bool continua = true;
        while (continua)
        {
            Console.WriteLine("Sei:\n 1. un dipendente; \n 2. Un cliente; \n 0. Esci\n");
            string scelta = Console.ReadLine();
            Console.Clear();
            switch (scelta)
            {
                case "1":
                    bool temp = true;
                    while (temp)
                    {
                        Console.WriteLine("Sei:\n1. Admin; \n2. Magazziniere; \n3. Cassiere; \n0. Esci;");
                        string ruolo = InputManager.LeggiIntero("\nScelta:", 0, 3).ToString();
                        Console.Clear();
                        switch (ruolo)
                        {
                            case "1": //Ruolo Admin
                                GestioneAdmin(managerDipendente, repositoryDipendente);
                                break;

                            case "2":
                                GestioneMagazziniere(managerProdotto, repositoryProdotto, managerCategoria, repositoryCategoria);
                                break;
                        }
                        break;
                    }
                    break;
                case "2":
                    GestioneCliente(managerProdotto, repositoryProdotto, managerCliente, repositoryCliente);
                    break;
                case "0":
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }

        }
        Console.WriteLine("Grazie per aver visitato il Supermercato!");
    }


    static void GestioneAdmin(DipendenteManager managerDipendente, DipendenteRepository repositoryDipendente)
    {
        Console.WriteLine("\nBenvenuto Admin!");
        bool temp1 = true;
        while (temp1)
        {
            Console.WriteLine("\nCosa vuoi fare?\n");
            Console.WriteLine("1. Visualizza Dipendenti");
            Console.WriteLine("2. Aggiungi Dipendente");
            Console.WriteLine("3. Trova Dipendente per ID");
            Console.WriteLine("4. Aggiorna Dipendente");
            Console.WriteLine("5. Elimina Dipendente");
            Console.WriteLine("0. Salva ed Esci");
            string admin = InputManager.LeggiIntero("\nScelta:", 0, 6).ToString();
            Console.Clear();
            switch (admin)
            {
                case "1":
                    Console.WriteLine("\nDipendenti:");
                    managerDipendente.StampaDipendentiIncolonnati();
                    break;
                case "2":
                    string username = InputManager.LeggiStringa("\nUsername: ");
                    managerDipendente.AggiungiDipendente(new Dipendente { Username = username, Ruolo = selezionaRuolo() });
                    break;
                case "3":
                    int idDipendente = InputManager.LeggiIntero("\nID: ");
                    Dipendente DipendenteTrovato = managerDipendente.TrovaDipendente(idDipendente);
                    if (DipendenteTrovato != null)
                    {
                        Console.WriteLine($"\nDipendente trovato per ID {idDipendente}: {DipendenteTrovato.Username}");
                    }
                    else
                    {
                        Console.WriteLine($"\nDipendente non trovato per ID {idDipendente}");
                    }
                    break;
                case "4":
                    int idDipendenteDaAggiornare = InputManager.LeggiIntero("\nID: ");
                    string usernameNuovo = InputManager.LeggiStringa("\nUsername: ");
                    managerDipendente.AggiornaDipendente(idDipendenteDaAggiornare, new Dipendente { Username = usernameNuovo, Ruolo = selezionaRuolo() });
                    break;
                case "5":
                    int idDipendenteDaEliminare = InputManager.LeggiIntero("\nID: ");
                    managerDipendente.EliminaDipendente(idDipendenteDaEliminare);
                    break;
                case "0":
                    repositoryDipendente.SalvaDipendenti(managerDipendente.OttieniDipendenti());
                    temp1 = false; // imposto la variabile continua a false per uscire dal ciclo while
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprovare.");
                    break;
            }
        }
    }

    static void GestioneMagazziniere(ProdottoManager managerProdotto, ProdottoRepository repositoryProdotto, CategoriaManager managerCategoria, CategoriaRepository repositoryCategoria)
    {
        Console.WriteLine("\nBenvenuto Dipendente!");
        bool temp2 = true;
        while (temp2)
        {
            Console.WriteLine("\nCosa vuoi fare?");
            Console.WriteLine("1. Visualizza Prodotti");
            Console.WriteLine("2. Aggiungi Prodotto");
            Console.WriteLine("3. Trova Prodotto per ID");
            Console.WriteLine("4. Aggiorna Prodotto");
            Console.WriteLine("5. Elimina Prodotto");
            Console.WriteLine("6. Visualizza Categorie");
            Console.WriteLine("7. Aggiungi Categoria");
            Console.WriteLine("8. Trova Categoria per ID");
            Console.WriteLine("9. Aggiorna Categoria");
            Console.WriteLine("10. Elimina Categoria");
            Console.WriteLine("0. Salva ed Esci");

            string dip = InputManager.LeggiIntero("\nScelta:", 0, 10).ToString();
            Console.Clear();
            switch (dip)
            {
                //stampa Prodotti
                case "1":
                    Console.WriteLine("\nProdotti:");
                    managerProdotto.StampaProdottiIncolonnati();
                    break;

                //Aggiungi Prodotto
                case "2":
                    string nomeProd = InputManager.LeggiStringa("\nNome: ");
                    decimal prezzoProd = InputManager.LeggiDecimale("\nPrezzo: ");
                    int giacenzaProd = InputManager.LeggiIntero("\nGiacenza: ");
                    managerProdotto.AggiungiProdotto(new Prodotto { Nome = nomeProd, Prezzo = prezzoProd, Giacenza = giacenzaProd, categoria = selezionaCategoria() });
                    break;

                //Trova Prodotto
                case "3":
                    int idProdotto = InputManager.LeggiIntero("\nID: ");
                    Prodotto prodottoTrovato = managerProdotto.TrovaProdotto(idProdotto);
                    if (prodottoTrovato != null)
                    {
                        Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.Nome}");
                    }
                    else
                    {
                        Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
                    }
                    break;

                //Aggiorna Prodotto
                case "4":
                    int idProdottoDaAggiornare = InputManager.LeggiIntero("\nID: ");
                    string nomeNuovo = InputManager.LeggiStringa("\nNome: ");
                    decimal prezzoNuovo = InputManager.LeggiDecimale("\nPrezzo: ");
                    int giacenzaNuova = InputManager.LeggiIntero("\nGiacenza: ");
                    managerProdotto.AggiornaProdotto(idProdottoDaAggiornare, new Prodotto { Nome = nomeNuovo, Prezzo = prezzoNuovo, Giacenza = giacenzaNuova, categoria = selezionaCategoria() });
                    break;

                //Elimina Prodotto
                case "5":
                    int idProdottoDaEliminare = InputManager.LeggiIntero("\nID: ");
                    managerProdotto.EliminaProdotto(idProdottoDaEliminare);
                    break;

                //Visualizza categorie
                case "6":
                    Console.WriteLine("\nCategorie:");
                    managerCategoria.StampaCategorieIncolonnati();
                    break;

                //Aggiungi Categoria
                case "7":
                    string nomeCat = InputManager.LeggiStringa("\nNome: ");
                    managerCategoria.AggiungiCategoria(new Categoria { Nome = nomeCat });
                    break;

                //Trova Categoria
                case "8":
                    int idCategoria = InputManager.LeggiIntero("\nID: ");
                    Categoria categoriaTrovata = managerCategoria.TrovaCategoria(idCategoria);
                    if (categoriaTrovata != null)
                    {
                        Console.WriteLine($"\nCategoria trovata per ID {idCategoria}: {categoriaTrovata.Nome}");
                    }
                    else
                    {
                        Console.WriteLine($"\nCategoria non trovata per ID {idCategoria}");
                    }
                    break;

                //aggiorna Categoria:
                case "9":
                    int idCategoriaDaAggiornare = InputManager.LeggiIntero("\nID: ");
                    string nomeCatNuovo = InputManager.LeggiStringa("\nNome: ");
                    managerCategoria.AggiornaCategoria(idCategoriaDaAggiornare, new Categoria { Nome = nomeCatNuovo });
                    break;

                //Elimina Prodotto
                case "10":
                    int idCategoriaDaEliminare = InputManager.LeggiIntero("\nID: ");
                    managerCategoria.EliminaCategoria(idCategoriaDaEliminare);
                    break;

                //Salva ed esci
                case "0":
                    repositoryProdotto.SalvaProdotti(managerProdotto.OttieniProdotti());
                    repositoryCategoria.SalvaCategorie(managerCategoria.OttieniCategorie());
                    temp2 = false; // imposto la variabile continua a false per uscire dal ciclo while
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprovare.");
                    break;
            }
        }
    }

    static void GestioneCliente(ProdottoManager managerProdotto, ProdottoRepository repositoryProdotto, ClienteManager managerCliente, ClienteRepository repositoryCliente)
    {
        string NomeCliente = InputManager.LeggiStringa("\nLogin: \nUsername: ");
        Cliente cliente = managerCliente.TrovaClienteNome(NomeCliente);



        if (cliente != null)
        {
            Console.WriteLine($"\nBentornato {cliente.Username}!");
            bool temp2 = true;
            while (temp2)
            {
                Console.WriteLine("\nCosa vuoi fare?");
                Console.WriteLine("1. Visualizza Prodotti");
                Console.WriteLine("2. Aggiungi Prodotto al carrello");
                Console.WriteLine("3. Visualizza il carrello");
                Console.WriteLine("4. Aggiorna Prodotto nel carrello");
                Console.WriteLine("5. Elimina Prodotto dal carrello");
                Console.WriteLine("0. Salva ed Esci");

                string dip = InputManager.LeggiIntero("\nScelta:", 0, 10).ToString();
                Console.Clear();

                switch (dip)
                {
                    case "1":
                        // Stampa Prodotti Disponibili
                        Console.WriteLine("\nProdotti Disponibili:");
                        managerProdotto.StampaProdottiIncolonnati();
                        break;

                    case "2":
                        // Aggiungi Prodotto al carrello
                        Console.WriteLine("\nProdotti Disponibili:");
                        managerProdotto.StampaProdottiIncolonnati();
 
                        break;

                    case "3":
                        // Visualizza il carrello

                        break;

                    case "4":
                        // Aggiorna Prodotto nel carrello

                        break;

                    case "5":
                        // Elimina Prodotto dal carrello
                   
                        break;

                    case "0":
                        // Salva ed Esci
                        managerCliente.SalvaCliente();
                        Console.WriteLine("Dati salvati. Arrivederci!");
                        temp2 = false;
                        break;

                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
        }
        else
        {
            decimal credito = 100;
            managerCliente.AggiungiCliente(new Cliente { Username = NomeCliente, Credito = credito });
            Console.WriteLine($"Registrazione avvenuta con successo! \nBenvenuto {NomeCliente}");
             bool temp2 = true;
            while (temp2)
            {
                Console.WriteLine("\nCosa vuoi fare?");
                Console.WriteLine("1. Visualizza Prodotti");
                Console.WriteLine("2. Aggiungi Prodotto al carrello");
                Console.WriteLine("3. Visualizza il carrello");
                Console.WriteLine("4. Aggiorna Prodotto nel carrello");
                Console.WriteLine("5. Elimina Prodotto dal carrello");
                Console.WriteLine("0. Salva ed Esci");

                string dip = InputManager.LeggiIntero("\nScelta:", 0, 10).ToString();
                Console.Clear();

                switch (dip)
                {
                    case "1":
                        // Stampa Prodotti Disponibili
                        Console.WriteLine("\nProdotti Disponibili:");
                        managerProdotto.StampaProdottiIncolonnati();
                        break;

                    case "2":
                        // Aggiungi Prodotto al carrello
                        Console.WriteLine("\nProdotti Disponibili:");
                        managerProdotto.StampaProdottiIncolonnati();

                       
                        break;

                    case "3":
                        // Visualizza il carrello
                       
                        break;

                    case "4":
                        // Aggiorna Prodotto nel carrello
                       
                        break;

                    case "5":
                        // Elimina Prodotto dal carrello
                       
                        break;

                    case "0":
                        // Salva ed Esci
                        managerCliente.SalvaCliente();
                        Console.WriteLine("Dati salvati. Arrivederci!");
                        temp2 = false;
                        break;

                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
        }
    }

        static Categoria selezionaCategoria()
        {
            // Carica le categorie dal repository
            var categorie = new CategoriaManager(new CategoriaRepository().CaricaCategorie()).OttieniCategorie();

            // Se la lista delle categorie è vuota
            if (categorie.Count == 0)
            {
                Console.WriteLine("Non ci sono categorie disponibili.");
                return null; // Oppure gestisci il caso come preferisci
            }

            // Stampa la lista delle categorie
            Console.WriteLine("Seleziona una categoria: ");
            for (int i = 0; i < categorie.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categorie[i].Nome}");
            }

            // Ottieni l'input dell'utente in un range valido
            int sceltaCategoria = InputManager.LeggiIntero("Seleziona un'operazione", 1, categorie.Count);

            // Restituisci la categoria selezionata
            return categorie[sceltaCategoria - 1];
        }

        static Ruolo selezionaRuolo()
        {
            var ruoli = new RuoloManager(new RuoloRepository().CaricaRuoli()).OttieniRuoli();

            if (ruoli.Count == 0)
            {
                Console.WriteLine("Non ci sono ruoli disponibili.");
                return null;
            }

            Console.WriteLine("Seleziona un ruolo: ");
            for (int i = 0; i < ruoli.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ruoli[i].ruoloNome}");
            }

            // Ottieni l'input dell'utente in un range valido
            int sceltaRuolo = InputManager.LeggiIntero("Seleziona un'operazione", 1, ruoli.Count);

            // Restituisci la categoria selezionata
            return ruoli[sceltaRuolo - 1];
        }

}
