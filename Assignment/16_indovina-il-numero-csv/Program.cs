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

        PersistenzaCsv(tentativiUtenti, nomeUtente);

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
    Console.WriteLine($"punteggio {punteggio} tentativi {tentativi}");
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
//------------------------------------ funzione persistenza csv------------------------------------
void PersistenzaCsv(Dictionary<string, List<int>> tentativiUtenti, string nomeUtente)
{
    
    string nomeFile = @"partite_salvate.csv";
    string[] dati_gioco = new string[7];

    dati_gioco[0] = nomeUtente;
    dati_gioco[1] = " ";
    dati_gioco[2] = "punteggio: ";
    dati_gioco[3] = Convert.ToString(punteggio);
    dati_gioco[4] = " ";
    dati_gioco[5] = "tentativi: ";
    dati_gioco[6] = Convert.ToString(tentativi);

    for(int i = 0;i<7;i++)
    {
        File.AppendAllText(nomeFile,dati_gioco[i]);
    }
    File.AppendAllText(nomeFile,"\n");
}