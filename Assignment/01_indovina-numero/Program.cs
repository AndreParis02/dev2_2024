Console.Clear();
Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;
int punteggioLevato = 0;



Dictionary<string, List<int>> DatiUtente = new Dictionary<string, List<int>>(); // creo un dizionario per memorizzare i tentativi e il punteggio

string risposta = "s"; // inizializzo la risposta a "s" per far partire il gioco

do
{
    int scelta = 0;
    Console.WriteLine("Inserisci il tuo nome:");
    string nomeUtente = Console.ReadLine();
    do
    {
        Console.WriteLine("Scegli il livello di difficolta':");
        Console.WriteLine("1. Facile (1-50, 10 tentativi)");
        Console.WriteLine("2. Medio (1-100, 5 tentativi)");
        Console.WriteLine("3. Difficile (1-200, 5 tentativi)");

        bool successoLivelloDifficolta = int.TryParse(Console.ReadLine(), out scelta);
        // pulisco la console
        Console.Clear();
        if (!successoLivelloDifficolta || scelta < 1 || scelta > 3)
        {
            Console.WriteLine("Scelta non valida.");
        }
    } while (scelta < 1 || scelta > 3);

    switch (scelta)
    {
        case 1:
            numeroDaIndovinare = random.Next(1, 51);
            punteggio = 100;
            punteggioLevato = 5;
            tentativi = punteggio / punteggioLevato;
            
            break;
        case 2:
            numeroDaIndovinare = random.Next(1, 101);
            punteggio = 100;
            punteggioLevato = 10;
            tentativi = punteggio / punteggioLevato;
            break;
        case 3:
            numeroDaIndovinare = random.Next(1, 201);
            punteggio = 100;
            punteggioLevato = 20;
            tentativi = punteggio / punteggioLevato;
            break;
        default:
            Console.WriteLine("Scelta non valida.");
            break;
    }

    Console.WriteLine("Indovina il numero. Punteggio massimo: 100 punti.");

    while (!haIndovinato && tentativi > 0)
    {
        Console.Write("Tentativo: ");
        bool successo = int.TryParse(Console.ReadLine(), out numeroUtente);
        // pulisco la console
        Console.Clear();

        if (!successo)
        {
            Console.WriteLine("Inserisci un numero valido.");
            continue;
        }

        if(!DatiUtente.ContainsKey(nomeUtente))
    {
        DatiUtente.Add(nomeUtente, new List<int>());
    }
        DatiUtente[nomeUtente].Add(numeroUtente);
        punteggio = punteggio - punteggioLevato;
        tentativi--;

        if (numeroUtente < numeroDaIndovinare)
        {
            Console.WriteLine("Il numero da indovinare e' maggiore.");
        }
        else if (numeroUtente > numeroDaIndovinare)
        {
            Console.WriteLine("Il numero da indovinare e' minore.");
        }
        else
        {
            Console.WriteLine($"Hai indovinato! Punteggio: {punteggio}");
            haIndovinato = true;
        }

        if (!haIndovinato && tentativi == 0)
        {
            Console.WriteLine($"Hai esaurito i tentativi. Il numero era {numeroDaIndovinare}.");
        }
    }

    Console.WriteLine("Tentativi effettuati: ");

    foreach (var DatiUtenti in DatiUtente)
    {
        Console.WriteLine($"{DatiUtenti.Key}\t{string.Join(", ", DatiUtenti.Value)}");
    }

    Console.WriteLine("Vuoi giocare di nuovo? (s/n)");
    risposta = Console.ReadLine();
    // pulisco la console
        Console.Clear();
    while (risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
    {
        Console.WriteLine("Risposta non valida. Vuoi giocare di nuovo? (s/n)");
        risposta = Console.ReadLine();
        // pulisco la console
        Console.Clear();
    }
    haIndovinato = false; 
    //Lista.Clear(); // cancello i tentativi effettuati

} while (risposta == "s" || risposta == "S");