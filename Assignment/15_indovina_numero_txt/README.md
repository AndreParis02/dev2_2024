# Indovina numero

## Obiettivo

- Implementa la persistenza di gioco indovina numero sul file di testo

- Implementare una funzione che scrive l'elenco dei tentativi fatti dall'untetne su un file di testo

- il programma chiede all'utente di inserire il proprio nome e usa il nome utente per creare un nuovo file.

```csharp
Console.Clear();
Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;
string nomeUtente = "";
List <int> TentUtente = new List<int>();

Dictionary<string, List<int>> tentativiUtenti = new Dictionary<string, List<int>>(); // creo un dizionario per memorizzare i tentativi degli utenti

string risposta = "s";

do
{
    int scelta = ScegliDifficolta();

    switch (scelta)
    {
        case 1:
            numeroDaIndovinare = GeneraNumeroCasuale(1, 51);
            punteggio = 100;
            tentativi = 10;
            break;
        case 2:
            numeroDaIndovinare = GeneraNumeroCasuale(1, 101);
            punteggio = 200;
            tentativi = 7;
            break;
        case 3:
            numeroDaIndovinare = GeneraNumeroCasuale(1, 201);
            punteggio = 300;
            tentativi = 5;
            break;
        default:
            Console.WriteLine("Scelta non valida.");
            break;
    }

    Console.WriteLine("Inserisci il tuo nome:");
    nomeUtente = Console.ReadLine();

    IndovinaNumero(numeroDaIndovinare, tentativi, punteggio, tentativiUtenti, TentUtente);

    StampaTentativi(tentativiUtenti);

    PersistenzaTxt(TentUtente,nomeUtente, tentativi);

    GiocaAncora(risposta);

    haIndovinato = false;

} while (risposta == "s" || risposta == "S");

int ScegliDifficolta()
{
    int scelta = 0;

    do
    {
        Console.WriteLine("Scegli il livello di difficolta':");
        Console.WriteLine("1. Facile (1-50, 10 tentativi)");
        Console.WriteLine("2. Medio (1-100, 7 tentativi)");
        Console.WriteLine("3. Difficile (1-200, 5 tentativi)");

        bool successoLivelloDifficolta = int.TryParse(Console.ReadLine(), out scelta);
        // pulisco la console
        Console.Clear();
        if (!successoLivelloDifficolta || scelta < 1 || scelta > 3)
        {
            Console.WriteLine("Scelta non valida.");
        }
    } while (scelta < 1 || scelta > 3);

    return scelta;
}

int GeneraNumeroCasuale(int min, int max)
{
    return random.Next(min, max);
}

void IndovinaNumero(int numeroDaIndovinare, int tentativi, int punteggio, Dictionary<string, List<int>> tentativiUtenti, List<int> TentUtente)
{
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

        tentativi--;
        // aggiungo il tentativo alla lista del nomeUtente
        if (!tentativiUtenti.ContainsKey(nomeUtente))
        {
            tentativiUtenti.Add(nomeUtente, TentUtente);
        }

        tentativiUtenti[nomeUtente].Add(numeroUtente); // aggiungo il tentativo alla lista del nomeUtente uso [nomeUtente] per accedere alla lista del nomeUtente

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

    if (haIndovinato)
    {
        // stampa il punteggio dell utente
        Console.WriteLine($"Punteggio: {punteggio}");
    }
}

void StampaTentativi(Dictionary<string, List<int>> tentativiUtenti)
{
    Console.WriteLine("Tentativi effettuati: ");

    foreach (var tentativoUtente in tentativiUtenti)
    {
        Console.WriteLine($"{tentativoUtente.Key}: {string.Join(", ", tentativoUtente.Value)}"); // stampo i tentativi degli utenti
    }
}

void ChiediNomeUtente(Dictionary<string, List<int>> tentativiUtenti, string nomeUtente)
{
    Console.WriteLine("Inserisci il tuo nome:");
    nomeUtente = Console.ReadLine();
}

void GiocaAncora(string risposta)
{
    Console.WriteLine("Vuoi giocare di nuovo? (s/n)");

    risposta = Console.ReadLine();

    Console.Clear();

    while (risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
    {
        Console.WriteLine("Risposta non valida. Vuoi giocare di nuovo? (s/n)");
        risposta = Console.ReadLine();
        Console.Clear();
    }
    haIndovinato = false;

    // tentativiUtenti.Clear(); // cancello i tentativi degli utenti
}
//------------------------------------ funzione persistenza txt------------------------------------
void PersistenzaTxt(List<int> TentUtente, string nomeUtente, int tentativi)
{
    string path = $"{nomeUtente}.txt";
    for(int i = 0; i < tentativi; i++)
    {
        File.WriteAllLines(path, TentUtente.ConvertAll(n => n.ToString()));
    }
    
}
```

con streamWriter:

```csharp
Console.Clear();
Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;
string nomeUtente = "";
bool Continua = true;

Dictionary<string, List<int>> tentativiUtenti = new Dictionary<string, List<int>>(); // creo un dizionario per memorizzare i tentativi degli utenti

string risposta = "s";
while(Continua)
{
    do
    {
        int scelta = ScegliDifficolta();
        
            switch (scelta)
            {
                case 1:
                    numeroDaIndovinare = GeneraNumeroCasuale(1, 51);
                    punteggio = 100;
                    tentativi = 10;
                    break;
                case 2:
                    numeroDaIndovinare = GeneraNumeroCasuale(1, 101);
                    punteggio = 200;
                    tentativi = 7;
                    break;
                case 3:
                    numeroDaIndovinare = GeneraNumeroCasuale(1, 201);
                    punteggio = 300;
                    tentativi = 5;
                    break;
                case 0:
                    Continua = false;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }

            if(Continua == false)
            {
                break;
            }

        
        
        Console.WriteLine("Inserisci il tuo nome:");
        nomeUtente = Console.ReadLine();

        IndovinaNumero(numeroDaIndovinare, tentativi, punteggio, tentativiUtenti);

        StampaTentativi(tentativiUtenti);

        PersistenzaTxt(tentativiUtenti, nomeUtente);

        GiocaAncora(risposta);

        haIndovinato = false;
        

    } while (risposta == "s" || risposta == "S");
}

int ScegliDifficolta()
{
    int scelta = 0;

    do
    {
        Console.WriteLine("Scegli il livello di difficolta':");
        Console.WriteLine("1. Facile (1-50, 10 tentativi)");
        Console.WriteLine("2. Medio (1-100, 7 tentativi)");
        Console.WriteLine("3. Difficile (1-200, 5 tentativi)");
        Console.WriteLine("0. Exit");
        

        bool successoLivelloDifficolta = int.TryParse(Console.ReadLine(), out scelta);
        // pulisco la console
        Console.Clear();
        if (!successoLivelloDifficolta || scelta < 0 || scelta > 3)
        {
            Console.WriteLine("Scelta non valida.");
        }
    } while (scelta < 0 || scelta > 3);

    return scelta;
}

int GeneraNumeroCasuale(int min, int max)
{
    return random.Next(min, max);
}

void IndovinaNumero(int numeroDaIndovinare, int tentativi, int punteggio, Dictionary<string, List<int>> tentativiUtenti)
{
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

        tentativi--;
        // aggiungo il tentativo alla lista del nomeUtente
        if (!tentativiUtenti.ContainsKey(nomeUtente))
        {
            tentativiUtenti.Add(nomeUtente, new List<int>());
        }

        tentativiUtenti[nomeUtente].Add(numeroUtente); // aggiungo il tentativo alla lista del nomeUtente uso [nomeUtente] per accedere alla lista del nomeUtente

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

    if (haIndovinato)
    {
        // stampa il punteggio dell utente
        Console.WriteLine($"Punteggio: {punteggio}");
    }
}

void StampaTentativi(Dictionary<string, List<int>> tentativiUtenti)
{
    Console.WriteLine("Tentativi effettuati: ");
    
    foreach (var tentativoUtente in tentativiUtenti)
    {
        Console.WriteLine($"{tentativoUtente.Key}: {string.Join(", ", tentativoUtente.Value)}"); // stampo i tentativi degli utenti
    }

}

void GiocaAncora(string risposta)
{
    Console.WriteLine("Vuoi giocare di nuovo? (s/n)");

    risposta = Console.ReadLine();

    Console.Clear();

    while (risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
    {
        Console.WriteLine("Risposta non valida. Vuoi giocare di nuovo? (s/n)");
        risposta = Console.ReadLine();
        Console.Clear();
    }
    haIndovinato = false;

    // tentativiUtenti.Clear(); // cancello i tentativi degli utenti
}
//------------------------------------ funzione persistenza txt------------------------------------
void PersistenzaTxt(Dictionary<string, List<int>> tentativiUtenti, string nomeUtente)
{
    if (Directory.Exists(@"Dati_Utenti"))
    {
        string nomeFile = $"{nomeUtente}.txt";

        string filePath = Path.Combine(@"Dati_Utenti",nomeFile);

        using (StreamWriter sw = new StreamWriter(filePath, append: true))
        {
            foreach (var tentativoUtente in tentativiUtenti)
            {
                if(tentativoUtente.Key == nomeUtente)
                {
                    sw.WriteLine($"{tentativoUtente.Key}: {string.Join(", ", tentativoUtente.Value)}");
                }
            }
        }

    }
    else
    {
        string nomeFile = $"{nomeUtente}.txt";
        string dir = @"Dati_Utenti";
        Directory.CreateDirectory(dir);

        string filePath = Path.Combine(@"Dati_Utenti",nomeFile);

        using (StreamWriter sw = new StreamWriter(filePath, append: true))
        {
            foreach (var tentativoUtente in tentativiUtenti)
            {
                if(tentativoUtente.Key == nomeUtente)
                {
                    sw.WriteLine($"{tentativoUtente.Key}: {string.Join(", ", tentativoUtente.Value)}");
                }
            }
        }
    }   
}
```