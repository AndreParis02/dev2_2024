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