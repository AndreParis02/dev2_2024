# Sorteggio partecipanti

## Versione 1

**Obiettivo:**

- Scrivere un programma che permetta di sorteggiare i partecipanti del corso da una lista di nomi.
- I nomi vengono gestiti senza un inserimento da parte dell'utente (cioè vengono inizializzati nel programma).
- Il programma estrae un partecipante singolo alla volta e lo stampa a video.
- chiede all'utente se vuole continuare a sorteggiare.
- Quando la lista risulta vuota termina.

**Istruzioni:**
- Crea una lista di string e la inizializzo con i nomi dei partecipanti.
- Tramite Random sorteggio un numero casuale da 0 al numero massimo dei partecipanti.
- Chiedo all'utente se vuole continuare a sorteggiare.
- Quando la lista risulta vuota il programma termina.

>**Esempio codice:**

```csharp
Random random = new Random();

List<string> partecipanti = new List<string>() {"Andrea", "Anita", "Ivan", "Diego", "Sofia", "Giorgio", "Felipe", "Tamer" }; 

int numeroSorteggiato;

partecipanti.Sort(); // ordina gli elementi di partecipanti

string risposta = "s"; 



    do
    {
        if(partecipanti.Count > 0)
        {
            numeroSorteggiato = random.Next(0, partecipanti.Count);

            Console.WriteLine($"Il nome estratto è: {partecipanti[numeroSorteggiato]}");

            partecipanti.RemoveAt(numeroSorteggiato);

            Console.WriteLine("Vuoi sorteggiare ancora? (s/n)");
            risposta = Console.ReadLine();
            
            Console.Clear();

            while (risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
            {
                Console.WriteLine("Risposta non valida. Vuoi sorteggiare ancora? (s/n)");
                risposta = Console.ReadLine();
            
                Console.Clear();

                partecipanti.RemoveAt(numeroSorteggiato);
            }
        }else
        {
            Console.WriteLine("La lista è vuota!");
        break;
        }

    } while (risposta == "s" || risposta == "S");

```

### Comandi versionamento

```bash
git add --all
git commit -m "Sorteggio partecipanti: Versione 1"
git push -u origin main
```
---

## FLOWCHART

```mermaid
flowchart LR
    A([Start])--> B{La Lista è vuota?}
    B-->|No|C(Sorteggia il nome)
    B-->|Si|E
    C-->D{Vuoi sorteggiare un altro nome?}
   D-->|Si|B
   D-->|No|E([End])
   ```

   ## Versione 2

**Obiettivo:**
- Scrivere un programma che permetta di sorteggiare i partecipanti del corso di una lista di nomi dividendoli in gruppi.
- Il programma deve chiedere all'utente il numero di squadre.
- Se il numero dei partecipanti non è divisibile per il numero di squadre, i partecipanti rimanenti viengono assegnati in modo casuale 

>**Esempio codice:**

```csharp
// creo la lista dei partecipanti
List<string> partecipanti = new List<string> { "Partecipante 1", "Partecipante 2", "Partecipante 3", "Partecipante 4", "Partecipante 5", "Partecipante 6", "Partecipante 7", "Partecipante 8", "Partecipante 9", "Partecipante 10" };

// creo un oggetto Random per generare numeri casuali
Random random = new Random();

// chiedo all'utente il numero di squadre
Console.WriteLine("Inserisci il numero di squadre:");
int numeroSquadre = int.Parse(Console.ReadLine());

// creo un array di liste di stringhe per le squadre
List<string>[] squadre = new List<string>[numeroSquadre];

// per ogni squadra creo una lista vuota
for (int i = 0; i < numeroSquadre; i++)
{
    squadre[i] = new List<string>();
}

// calcolo quanti partecipanti ci sono in ogni squadra
int partecipantiPerSquadra = partecipanti.Count / numeroSquadre;

// se il numero di partecipanti non è divisibile per il numero di squadre, aggiungo un partecipante in piu ad una squadra

// calcolo quanti partecipanti ci sono in piu
int partecipantiInPiu = partecipanti.Count % numeroSquadre;

// per ogni squadra
for (int i = 0; i < numeroSquadre; i++)
{
    // per ogni partecipante della squadra

    for (int j = 0; j < partecipantiPerSquadra; j++)
    {
        // genero un numero casuale tra 0 e il numero di partecipanti rimasti
        int index = random.Next(partecipanti.Count);
        // aggiungo il partecipante alla squadra
        squadre[i].Add(partecipanti[index]);
        // rimuovo il partecipante dalla lista dei partecipanti
        partecipanti.RemoveAt(index);
    }

    // se ci sono partecipanti in piu, aggiungo un partecipante in piu alla squadra corrente
    if (partecipantiInPiu > 0)
    {
        // genero un numero casuale tra 0 e il numero di partecipanti rimasti
        int index = random.Next(partecipanti.Count);
        // aggiungo il partecipante alla squadra
        squadre[i].Add(partecipanti[index]);
        // rimuovo il partecipante dalla lista dei partecipanti
        partecipanti.RemoveAt(index);
        // decremento il numero di partecipanti in piu
        partecipantiInPiu--;
    }

    // stampo i partecipanti della squadra
    Console.WriteLine($"Squadra {i + 1}:");
    foreach (string partecipante in squadre[i])
    {
        Console.WriteLine(partecipante);
    }
    Console.WriteLine();
}
```

### Comandi versionamento

```bash
git add --all
git commit -m "Sorteggio partecipanti: Versione 2"
git push -u origin main
```

 ## Versione 3

**Obiettivo:**
- Scrivere un programma che permetta di sorteggiare i partecipanti del corso da una lista di nomi dividendo i partecipanti in gruppi.
- Il programma deve usare un dizionario che ha come chiavi i numeri delle squadre e come valori le liste dei partecipanti di ogni squadra.

>**Esempio codice:**

```csharp
// creo la lista dei partecipanti
List<string> partecipanti = new List<string> { "Partecipante 1", "Partecipante 2", "Partecipante 3", "Partecipante 4", "Partecipante 5", "Partecipante 6", "Partecipante 7", "Partecipante 8", "Partecipante 9", "Partecipante 10" };

// creo un oggetto Random per generare numeri casuali
Random random = new Random();

// chiedo all'utente il numero di squadre
Console.WriteLine("Inserisci il numero di squadre:");
int numeroSquadre = int.Parse(Console.ReadLine());

// creo un dizionario per le squadre
Dictionary<int, List<string>> squadre = new Dictionary<int, List<string>>();

// per ogni squadra
for (int i = 0; i < numeroSquadre; i++)
{
    // aggiungo la squadra al dizionario
    squadre.Add(i + 1, new List<string>());
}

// calcolo quanti partecipanti ci sono in ogni squadra
int partecipantiPerSquadra = partecipanti.Count / numeroSquadre;

// se il numero di partecipanti non è divisibile per il numero di squadre, aggiungo un partecipante in piu ad una squadra
int partecipantiInPiu = partecipanti.Count % numeroSquadre;

// per ogni squadra
for (int i = 0; i < numeroSquadre; i++)
{
    // aggiungo i partecipanti
    for (int j = 0; j < partecipantiPerSquadra; j++)
    {
        // genero un numero casuale tra 0 e il numero di partecipanti rimasti
        int index = random.Next(partecipanti.Count);
        // aggiungo il partecipante alla squadra
        squadre[i + 1].Add(partecipanti[index]);
        // rimuovo il partecipante dalla lista dei partecipanti
        partecipanti.RemoveAt(index);
    }

    // se ci sono partecipanti in piu, aggiungo un partecipante in piu alla squadra corrente
    if (partecipantiInPiu > 0)
    {
        // genero un numero casuale tra 0 e il numero di partecipanti rimasti
        int index = random.Next(partecipanti.Count);
        // aggiungo il partecipante alla squadra
        squadre[i + 1].Add(partecipanti[index]);
        // rimuovo il partecipante dalla lista dei partecipanti
        partecipanti.RemoveAt(index);
        // decremento il numero di partecipanti in piu
        partecipantiInPiu--;
    }

    // stampo i partecipanti della squadra
    Console.WriteLine($"Squadra {i + 1}:");
    foreach (string partecipante in squadre[i + 1])
    {
        Console.WriteLine(partecipante);
    }
    Console.WriteLine();
}
```

### Comandi versionamento

```bash
git add --all
git commit -m "Sorteggio partecipanti: Versione 3"
git push -u origin main
```

## Versione 4

**Obiettivo:**
- Scrivere un programma che permetta di sorteggiare i partecipanti del corso da una lista di nomi dividendo i partecipanti in gruppi.
- Il programma deve stampare la lista dei partecipanti
- Il programma deve chiedere all utente di inserire o eliminare un partecipante presente nella lista iniziale o fare il sorteggio.

>**Esempio codice:**

```csharp

// creo la lista dei partecipanti
List<string> partecipanti = new List<string> { "Partecipante 1", "Partecipante 2", "Partecipante 3", "Partecipante 4", "Partecipante 5", "Partecipante 6", "Partecipante 7", "Partecipante 8", "Partecipante 9", "Partecipante 10" };

// creo un oggetto Random per generare numeri casuali
Random random = new Random();

// pulisco la console
Console.Clear();

// stampo la lista dei partecipanti
Console.WriteLine("Partecipanti:");
foreach (string partecipante in partecipanti)
{
    Console.WriteLine(partecipante);
}

// chiedo all utente se vuole inserire o eliminare un partecipante o sorteggiare i partecipanti
while (true)
{
    Console.WriteLine("Vuoi inserire un partecipante, eliminare un partecipante o sorteggiare i partecipanti? (i/e/s)");
    string risposta = Console.ReadLine();
    // pulisco la console
    Console.Clear();
    if (risposta == "i")
    {
        Console.WriteLine("Inserisci il nome del partecipante:");
        string partecipante = Console.ReadLine();
        partecipanti.Add(partecipante);
    }
    else if (risposta == "e")
    {
        Console.WriteLine("Inserisci il nome del partecipante:");
        string partecipante = Console.ReadLine();
        partecipanti.Remove(partecipante);
    }
    else if (risposta == "s")
    {
        // chiedo all'utente il numero di squadre
        Console.WriteLine("Inserisci il numero di squadre:");
        int numeroSquadre = int.Parse(Console.ReadLine());

        // creo una lista per ogni squadra
        List<string>[] squadre = new List<string>[numeroSquadre];
        for (int i = 0; i < numeroSquadre; i++)
        {
            squadre[i] = new List<string>();
        }

        // calcolo quanti partecipanti ci sono in ogni squadra
        int partecipantiPerSquadra = partecipanti.Count / numeroSquadre;

        // se il numero di partecipanti non è divisibile per il numero di squadre, aggiungo un partecipante in più ad una squadra
        int partecipantiInPiù = partecipanti.Count % numeroSquadre;

        // per ogni squadra
        for (int i = 0; i < numeroSquadre; i++)
        {
            // aggiungo i partecipanti
            for (int j = 0; j < partecipantiPerSquadra; j++)
            {
                // genero un numero casuale tra 0 e il numero di partecipanti rimasti
                int index = random.Next(partecipanti.Count);
                // aggiungo il partecipante alla squadra
                squadre[i].Add(partecipanti[index]);
                // rimuovo il partecipante dalla lista dei partecipanti
                partecipanti.RemoveAt(index);
            }

            // se ci sono partecipanti in più, aggiungo un partecipante in più alla squadra corrente
            if (partecipantiInPiù > 0)
            {
                // genero un numero casuale tra 0 e il numero di partecipanti rimasti
                int index = random.Next(partecipanti.Count);
                // aggiungo il partecipante alla squadra
                squadre[i].Add(partecipanti[index]);
                // rimuovo il partecipante dalla lista dei partecipanti
                partecipanti.RemoveAt(index);
                // decremento il numero di partecipanti in più
                partecipantiInPiù--;
            }

            // stampo i partecipanti della squadra
            Console.WriteLine($"Squadra {i + 1}:");
            foreach (string partecipante in squadre[i])
            {
                Console.WriteLine(partecipante);
            }
            Console.WriteLine();
        }
        break;
    }
    // stampo la lista dei partecipanti
    Console.WriteLine("Partecipanti:");
    foreach (string partecipante in partecipanti)
    {
        Console.WriteLine(partecipante);
    }
}
```

### Comandi versionamento

```bash
git add --all
git commit -m "Sorteggio partecipanti: Versione 4"
git push -u origin main
```

