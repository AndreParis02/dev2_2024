# INDOVINA NUMERO

## Obiettivo:

l'obiettivo di questa applicazione e' di indovinare il **numero casuale** generato dal computer.

>Passaggi:

1. Il computer confronta il numero inserito con quello generato.
2. L'utente inserisce un numero.
3. Il computer confronta il numero inserito con quello generato.
4. Se il numero inserito è uguale a quello generato, l'utente ha indovinato.
5. Altrimenti, il computer fornisce un suggerimento (maggiore o minore) e l'utente può inserire un nuovo numero.
6. Il gioco termina quando l'utente indovina il numero o quando raggiunge il numero massimo di tentativi.

>**Esempio codice:**

## Versione 1

```csharp
Random random = new Random();// Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101);// Next e il metodo che genera un numero casuale tra 1 e 100

Console.WriteLine("Indovina il numero (tra 1 e 100): ");

int numeroInserito;

numeroInserito = Convert.ToInt32(Console.ReadLine());// converto il valore inserito dall'utente in un intero perche Console.ReadLine restituisce una stringa
if (numeroInserito == numeroDaIndovinare)
{
    Console.WriteLine("Complimenti! Hai indovinato il numero.");
}
else
{
    Console.WriteLine("Mi dispiace! Non hai indovinato il numero.");

    Console.WriteLine($"Il numero da indovinare era: {numeroDaIndovinare}");
}
```
### Comandi versionamento

```bash
git add --all
git commit -m "Indovina numero: Versione 1"
git push -u origin main
```

## Versione 2

**Obiettivo:**
Modifica il programma precedente per fornire all'utente suggerimenti dopo ogni tentativo, indicando se il numero da indovinare è maggiore o minore di quello inserito.

**Istruzioni:**

* Usa un ciclo while per permettere all'utente di continuare a tentare finchè non indovina.
* Dopo ogni tentativo errato, indica se il numero da indovinare è maggiore o minore di quello inserito.
* Quando l'utente indovina, esci dal ciclo e stampa un messaggio di congratulazioni.

>**Esempio codice:**

## Versione 2

```csharp
Random random = new Random();// Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101);// Next e il metodo che genera un numero casuale tra 1 e 100

Console.Clear();

Console.WriteLine("Indovina il numero (tra 1 e 100): ");

int numeroInserito;

numeroInserito = 0; //inizializzo a 0 per entrare nel ciclo while

while (numeroInserito != numeroDaIndovinare)
{
    numeroInserito = Convert.ToInt32(Console.ReadLine());

    if (numeroInserito < numeroDaIndovinare)
    {
        Console.WriteLine("Il numero da indovinare e' maggiore");
    }
    else
    {
        Console.WriteLine("Il numero da indovinare e' minore");
    }

Console.WriteLine("Riprova: ");
}

Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}");
```
### Comandi versionamento

```bash
git add --all
git commit -m "Indovina numero: Versione 2"
git push -u origin main
```
## Versione 3

**Obiettivo:**
Imposta un numero massimo di tentativa ( ad esempio 5). Se l'utente indovina entro questi tentativi, il gioco termina.

>**Esempio codice:**

```csharp
Random random = new Random();// Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101);// Next e il metodo che genera un numero casuale tra 1 e 100

Console.Clear();

Console.WriteLine("Indovina il numero (tra 1 e 100): ");

int numeroInserito;
int numTentativi = 5;

for(int i = 0; i < 5; i++)
{
    numTentativi --;
    numeroInserito = Convert.ToInt32(Console.ReadLine());

        if(numeroInserito != numeroDaIndovinare && numTentativi != 0)
        {
            if(numeroInserito < numeroDaIndovinare)
            {
                Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numTentativi} tentativi!");
                Console.WriteLine("Riprova: ");
            }else
            {
                Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numTentativi} tentativi!");
                Console.WriteLine("Riprova: ");
            }    
        }
        else if(numeroInserito == numeroDaIndovinare)
        {
            Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numTentativi} tentativi!");
            i = 5;
        }   
    }    
if( numTentativi == 0)
{
    Console.WriteLine($"Peccato non hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}");
}
```
### Comandi versionamento

```bash
git add --all
git commit -m "Indovina numero: Versione 3"
git push -u origin main
```

## Versione 4

**Obiettivo:**
Assegna un punteggio all'utente in base al numero di tentativi utilizzati. più tentativi impiega minore sarà il punteggio

**Istruzioni:**

* inizia con un punteggio massimo (es. 100 punti)
* Ad ogni tentativo fallito, sottrai un certo numero di punti (es. 20 punti)
* Alla fine del gioco mostra il punteggio dell'utente

>**Esempio codice:**

```csharp
Random random = new Random();// Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101);// Next e il metodo che genera un numero casuale tra 1 e 100

Console.Clear();

Console.WriteLine("Indovina il numero (tra 1 e 100): ");

int numeroInserito;
int totPunti = 100;
int numPunti = totPunti;

for(int i = 0; i < (totPunti/5); i++)
{
    numeroInserito = Convert.ToInt32(Console.ReadLine());
    numPunti -= 5;

        if(numeroInserito != numeroDaIndovinare && numPunti != 0)
        {
            if(numeroInserito < numeroDaIndovinare)
            {
                Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numPunti} punti!");
                Console.WriteLine("Riprova: ");
            }else
            {
                Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numPunti} punti!");
                Console.WriteLine("Riprova: ");
            }    
        }
        else if(numeroInserito == numeroDaIndovinare)
        {
            Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numPunti} punti!");
            i = totPunti/5;
        }   
        
    }    
if( numPunti == 0)
{
    Console.WriteLine($"Peccato non hai indovinato ed hai finito tutti i punti! Il numero da indovinare era: {numeroDaIndovinare}");
}
```
### Comandi versionamento

```bash
git add --all
git commit -m "Indovina numero: Versione 4"
git push -u origin main
```

## Versione 5

**Obiettivo:**
Permetti all'utente di scegliere tra i diversi livelli di difficoltà che modificano il numero di punti sottrarri o l'intervallo dei numeri o il numero di tentativi possibili.

**Istruzioni:**

* in base ai livelli di difficoltà sottrai un tot di punti

>**Esempio codice:**

```csharp
Random random = new Random();// Random e la classe che genera numeri casuali
int numeroInserito;
int totPunti;
int numPunti;
int numeroDaIndovinare;

Console.Clear();

Console.WriteLine("scegli il livello di difficolta':");
Console.WriteLine("difficoltà facile (f) Indovina il numero (tra 1 e 50),20 tentativi, 100 punti totali");
Console.WriteLine("difficoltà media (m) Indovina il numero (tra 1 e 100),10 tentativi, 100 punti totali");
Console.WriteLine("difficoltà difficile (d) Indovina il numero (tra 1 e 500),5 tentativi, 500 punti totali");
Console.WriteLine("difficoltà impossibile (i) Indovina il numero (tra 1 e 1000),5 tentativi, 1000 punti totali");

string difficoltà = Console.ReadLine();
switch (difficoltà)
{
    case "f":
        Console.WriteLine("Hai scelto la modalità facile");

        numeroDaIndovinare = random.Next(1, 51);

        Console.WriteLine("Indovina il numero (tra 1 e 50): ");

        totPunti = 100;
        numPunti = totPunti;


        for(int i = 0; i < (totPunti/5); i++)
        {
            numeroInserito = Convert.ToInt32(Console.ReadLine());
            numPunti -= 5;

                if(numeroInserito != numeroDaIndovinare && numPunti != 0)
                {
                    if(numeroInserito < numeroDaIndovinare)
                    {
                        Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }else
                    {
                        Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }    
                }
                else if(numeroInserito == numeroDaIndovinare)
                {
                    Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numPunti} punti!");
                    i = totPunti/5;
                }   
                
            }    
        if( numPunti == 0)
        {
            Console.WriteLine($"Peccato non hai indovinato ed hai finito tutti i punti! Il numero da indovinare era: {numeroDaIndovinare}");
        }
        break;

    case "m":
        
         Console.WriteLine("Hai scelto la modalità media");

        numeroDaIndovinare = random.Next(1, 101);

        Console.WriteLine("Indovina il numero (tra 1 e 100): ");

        totPunti = 100;
        numPunti = totPunti;


        for(int i = 0; i < (totPunti/10); i++)
        {
            numeroInserito = Convert.ToInt32(Console.ReadLine());
            numPunti -= 10;

                if(numeroInserito != numeroDaIndovinare && numPunti != 0)
                {
                    if(numeroInserito < numeroDaIndovinare)
                    {
                        Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }else
                    {
                        Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }    
                }
                else if(numeroInserito == numeroDaIndovinare)
                {
                    Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numPunti} punti!");
                    i = totPunti/10;
                }   
                
            }    
        if( numPunti == 0)
        {
            Console.WriteLine($"Peccato non hai indovinato ed hai finito tutti i punti! Il numero da indovinare era: {numeroDaIndovinare}");
        }

        break;

         case "d":
        
         Console.WriteLine("Hai scelto la modalità difficile");

        numeroDaIndovinare = random.Next(1, 501);

        Console.WriteLine("Indovina il numero (tra 1 e 500): ");

        totPunti = 500;
        numPunti = totPunti;


        for(int i = 0; i < (totPunti/100); i++)
        {
            numeroInserito = Convert.ToInt32(Console.ReadLine());
            numPunti -= 100;

                if(numeroInserito != numeroDaIndovinare && numPunti != 0)
                {
                    if(numeroInserito < numeroDaIndovinare)
                    {
                        Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }else
                    {
                        Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }    
                }
                else if(numeroInserito == numeroDaIndovinare)
                {
                    Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numPunti} punti!");
                    i = totPunti/100;
                }   
                
            }    
        if( numPunti == 0)
        {
            Console.WriteLine($"Peccato non hai indovinato ed hai finito tutti i punti! Il numero da indovinare era: {numeroDaIndovinare}");
        }

        break;

         case "i":
        
         Console.WriteLine("Hai scelto la modalità impossibile");

        numeroDaIndovinare = random.Next(1, 1001);

        Console.WriteLine("Indovina il numero (tra 1 e 1000): ");

        totPunti = 1000;
        numPunti = totPunti;


        for(int i = 0; i < (totPunti/200); i++)
        {
            numeroInserito = Convert.ToInt32(Console.ReadLine());
            numPunti -= 200;

                if(numeroInserito != numeroDaIndovinare && numPunti != 0)
                {
                    if(numeroInserito < numeroDaIndovinare)
                    {
                        Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }else
                    {
                        Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }    
                }
                else if(numeroInserito == numeroDaIndovinare)
                {
                    Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numPunti} punti!");
                    i = totPunti/200;
                }   
                
            }    
        if( numPunti == 0)
        {
            Console.WriteLine($"Peccato non hai indovinato ed hai finito tutti i punti! Il numero da indovinare era: {numeroDaIndovinare}");
        }

        break;

    default:
        Console.WriteLine("non hai selezionato nessun livello di difficoltà!");
        break;
}
```
### Comandi versionamento

```bash
git add --all
git commit -m "Indovina numero: Versione 5"
git push -u origin main
```

## Versione 6

**Obiettivo:**
Storico tentativi:Mostra all'utente tutti i numeri inseriti precedentemente.

**Istruzioni:**

* utilizza una lista per memorizzare i tentativi dell'utente.
I tentativi sono memorizzati fino a quando l'utente indovina il numero o esaurisce i tentativi ma vengono persi quando vieni eseguito il codice successivo.

>**Esempio codice:**

```csharp

Random random = new Random();
int numeroInserito;
int totPunti;
int numPunti;
int numeroDaIndovinare;

List <int> tentativiUtente = new List<int>(); //creo una lista per memoriazzare i tentativi dell'utente


Console.Clear();

Console.WriteLine("scegli il livello di difficolta':");
Console.WriteLine("difficoltà facile (f) Indovina il numero (tra 1 e 50),20 tentativi, 100 punti totali");
Console.WriteLine("difficoltà media (m) Indovina il numero (tra 1 e 100),10 tentativi, 100 punti totali");
Console.WriteLine("difficoltà difficile (d) Indovina il numero (tra 1 e 500),5 tentativi, 500 punti totali");
Console.WriteLine("difficoltà impossibile (i) Indovina il numero (tra 1 e 1000),5 tentativi, 1000 punti totali");

string difficoltà = Console.ReadLine();
switch (difficoltà)
{
    case "f":
        Console.WriteLine("Hai scelto la modalità facile");

        numeroDaIndovinare = random.Next(1, 51);

        Console.WriteLine("Indovina il numero (tra 1 e 50): ");

        totPunti = 100;
        numPunti = totPunti;


        for(int i = 0; i < (totPunti/5); i++)
        {
            numeroInserito = Convert.ToInt32(Console.ReadLine());
            numPunti -= 5;
            tentativiUtente.Add(numeroInserito);

                if(numeroInserito != numeroDaIndovinare && numPunti != 0)
                {
                    if(numeroInserito < numeroDaIndovinare)
                    {
                        Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }else
                    {
                        Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }    
                }
                else if(numeroInserito == numeroDaIndovinare)
                {
                    Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numPunti} punti!");
                    i = totPunti/5;
                }   
                
            }    
        if( numPunti == 0)
        {
            Console.WriteLine($"Peccato non hai indovinato ed hai finito tutti i punti! Il numero da indovinare era: {numeroDaIndovinare}");
        }
        break;

    case "m":
        
         Console.WriteLine("Hai scelto la modalità media");

        numeroDaIndovinare = random.Next(1, 101);

        Console.WriteLine("Indovina il numero (tra 1 e 100): ");

        totPunti = 100;
        numPunti = totPunti;


        for(int i = 0; i < (totPunti/10); i++)
        {
            numeroInserito = Convert.ToInt32(Console.ReadLine());
            numPunti -= 10;
            tentativiUtente.Add(numeroInserito);

                if(numeroInserito != numeroDaIndovinare && numPunti != 0)
                {
                    if(numeroInserito < numeroDaIndovinare)
                    {
                        Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }else
                    {
                        Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }    
                }
                else if(numeroInserito == numeroDaIndovinare)
                {
                    Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numPunti} punti!");
                    i = totPunti/10;
                }   
                
            }    
        if( numPunti == 0)
        {
            Console.WriteLine($"Peccato non hai indovinato ed hai finito tutti i punti! Il numero da indovinare era: {numeroDaIndovinare}");
        }

        break;

         case "d":
        
         Console.WriteLine("Hai scelto la modalità difficile");

        numeroDaIndovinare = random.Next(1, 501);

        Console.WriteLine("Indovina il numero (tra 1 e 500): ");

        totPunti = 500;
        numPunti = totPunti;


        for(int i = 0; i < (totPunti/100); i++)
        {
            numeroInserito = Convert.ToInt32(Console.ReadLine());
            numPunti -= 100;
            tentativiUtente.Add(numeroInserito);

                if(numeroInserito != numeroDaIndovinare && numPunti != 0)
                {
                    if(numeroInserito < numeroDaIndovinare)
                    {
                        Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }else
                    {
                        Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }    
                }
                else if(numeroInserito == numeroDaIndovinare)
                {
                    Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numPunti} punti!");
                    i = totPunti/100;
                }   
                
            }    
        if( numPunti == 0)
        {
            Console.WriteLine($"Peccato non hai indovinato ed hai finito tutti i punti! Il numero da indovinare era: {numeroDaIndovinare}");
        }

        break;

         case "i":
        
         Console.WriteLine("Hai scelto la modalità impossibile");

        numeroDaIndovinare = random.Next(1, 1001);

        Console.WriteLine("Indovina il numero (tra 1 e 1000): ");

        totPunti = 1000;
        numPunti = totPunti;


        for(int i = 0; i < (totPunti/200); i++)
        {
            numeroInserito = Convert.ToInt32(Console.ReadLine());
            numPunti -= 200;
            tentativiUtente.Add(numeroInserito);

                if(numeroInserito != numeroDaIndovinare && numPunti != 0)
                {
                    if(numeroInserito < numeroDaIndovinare)
                    {
                        Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }else
                    {
                        Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }    
                }
                else if(numeroInserito == numeroDaIndovinare)
                {
                    Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numPunti} punti!");
                    i = totPunti/200;
                }   
                
            }    
        if( numPunti == 0)
        {
            Console.WriteLine($"Peccato non hai indovinato ed hai finito tutti i punti! Il numero da indovinare era: {numeroDaIndovinare}");
        }

        break;

    default:
        Console.WriteLine("non hai selezionato nessun livello di difficoltà!");
        break;
}

Console.WriteLine("tentativi effettuati: ");
foreach(int tentativo in tentativiUtente)
{
    Console.Write($"{tentativo} "); //stampo i tentativi effettuati
}

```

### Comandi versionamento

```bash
git add --all
git commit -m "Indovina numero: Versione 6"
git push -u origin main
```

## Versione 7

**Obiettivo:**

Validazione degli input: aggiungi controlli per assicurare che l'utente iserisca un numero vaildo.

**Istruzioni:**

* utilizza il metodo `int.TryParse` per convertire l'input dell'utente in numero intero

>**Esempio codice:**

```csharp
/*
int numeroUtente;

bool successo = int.TryParse(Console.ReadLine(), out numeroUtente);

if (successo)
{
    // il numeroUtente e' stato convertito correttamente
    // posso usare il valore di numeroUtente
}
else
{
    // l'utente ha inserito un valore non valido
    Console.WriteLine("Inserisci un numero valido.");
    continue; // salto il resto del ciclo e vado al prossimo tentativo
}
*/
Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;

List<int> tentativiUtente = new List<int>();

Console.WriteLine("Scegli il livello di difficolta':");
Console.WriteLine("1. Facile (1-50, 10 tentativi)");
Console.WriteLine("2. Medio (1-100, 7 tentativi)");
Console.WriteLine("3. Difficile (1-200, 5 tentativi)");

// int scelta = int.Parse(Console.ReadLine());
int scelta = 0; // Inizializzo la variabile scelta a 0
bool successoLivelloDifficolta = int.TryParse(Console.ReadLine(), out scelta); // TryParse restituisce true se la conversione è riuscita, altrimenti false

// se la conversione non è riuscita oppure la scelta non è compresa tra 1 e 3
if (!successoLivelloDifficolta || scelta < 1 || scelta > 3)
{
    Console.WriteLine("Scelta non valida."); // Stampo un messaggio di errore
}
else
{
    switch (scelta)
    {
        case 1:
            numeroDaIndovinare = random.Next(1, 51);
            punteggio = 100;
            tentativi = 10;
            break;
        case 2:
            numeroDaIndovinare = random.Next(1, 101);
            punteggio = 100;
            tentativi = 7;
            break;
        case 3:
            numeroDaIndovinare = random.Next(1, 201);
            punteggio = 100;
            tentativi = 5;
            break;
        default:
            Console.WriteLine("Scelta non valida.");
            break;
    }

    Console.WriteLine("Indovina il numero. Punteggio massimo: 100 punti.");

    while (!haIndovinato && tentativi > 0)
    {
        Console.Write("Tentativo: ");
        bool successo = int.TryParse(Console.ReadLine(), out numeroUtente); // TryParse restituisce true se la conversione è riuscita, altrimenti false

        if (!successo)
        {
            Console.WriteLine("Inserisci un numero valido."); // Se l'utente non ha inserito un numero valido, si salta il tentativo
            continue; // Salta il resto del ciclo e va al prossimo tentativo
        }

        tentativiUtente.Add(numeroUtente);
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

    foreach (int tentativo in tentativiUtente)
    {
        Console.Write($"{tentativo} ");
    }
}

```

### Comandi versionamento

```bash
git add --all
git commit -m "Indovina numero: Versione 7"
git push -u origin main
```
## Versione 8

**Obiettivo:**

Ripetizione del Livello: Chiedi all'utente di inserire il livello di difficoltà finché non sceglie un livello valido.

**Istruzioni:**

Se vogliamo che chieda di nuovo il livello di difficoltà quando la scelta non è valida dobbiamo mettere tutto il codice precedente in un ciclo do-while e fare in modo che il ciclo si ripeta finché la scelta non è valida

Con un semplice while non possiamo fare in modo che il ciclo si ripeta finché la scelta non è valida, perché il ciclo while si ripete finché la condizione è vera, ma non possiamo sapere se la scelta è valida o meno finché non la controlliamo.

Quindi dobbiamo usare un ciclo do-while, che esegue il blocco di codice almeno una volta e poi si ripete finché la condizione è vera.

>**Esempio codice:**

```csharp
Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;

List<int> tentativiUtente = new List<int>();

int scelta = 0;

do{
    Console.WriteLine("Scegli il livello di difficolta':");
    Console.WriteLine("1. Facile (1-50, 10 tentativi)");
    Console.WriteLine("2. Medio (1-100, 7 tentativi)");
    Console.WriteLine("3. Difficile (1-200, 5 tentativi)");


    bool successoLivelloDifficolta = int.TryParse(Console.ReadLine(), out scelta); // TryParse restituisce true se la conversione è riuscita, altrimenti false

    // se la conversione non è riuscita oppure la scelta non è compresa tra 1 e 3
    if (!successoLivelloDifficolta || scelta < 1 || scelta > 3)
    {
        Console.WriteLine("Scelta non valida."); // Stampo un messaggio di errore
    }
}while (scelta < 1 || scelta > 3)
{
    switch (scelta)
    {
        case 1:
            numeroDaIndovinare = random.Next(1, 51);
            punteggio = 100;
            tentativi = 10;
            break;
        case 2:
            numeroDaIndovinare = random.Next(1, 101);
            punteggio = 100;
            tentativi = 7;
            break;
        case 3:
            numeroDaIndovinare = random.Next(1, 201);
            punteggio = 100;
            tentativi = 5;
            break;
        default:
            Console.WriteLine("Scelta non valida.");
            break;
    }

    Console.WriteLine("Indovina il numero. Punteggio massimo: 100 punti.");

    while (!haIndovinato && tentativi > 0)
    {
        Console.Write("Tentativo: ");
        bool successo = int.TryParse(Console.ReadLine(), out numeroUtente); // TryParse restituisce true se la conversione è riuscita, altrimenti false

        if (!successo)
        {
            Console.WriteLine("Inserisci un numero valido."); // Se l'utente non ha inserito un numero valido, si salta il tentativo
            continue; // Salta il resto del ciclo e va al prossimo tentativo
        }

        tentativiUtente.Add(numeroUtente);
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

    foreach (int tentativo in tentativiUtente)
    {
        Console.Write($"{tentativo} ");
    }
}
```

### Comandi versionamento

```bash
git add --all
git commit -m "Indovina numero: Versione 8"
git push -u origin main
```

## Versione 9

**Obiettivo:**

Ripetizione del gioco: chiedi all'utetne se vuole giocare di nuovo.

**Istruzioni:**

- Chiedi all'utente se vuole giocare di nuovo;
- Se l'utente risponde "s" o "S", il gioco ricomincia. Se l'utente risponde "n" o "N", il gioco termina.
- Verifichiamo con un TryCatch se l'utetne ha inserito un valore diverso da "s", "S", "n" o "N" e chiediamo di nuovo la risposta.
- Se l'utente risponde con un valore diverso, chiedi di nuovo la risposta

>**Esempio codice:**

```csharp
// Possiamo evitare la confusione tra lettere maiuscole o minuscole (S s, N n) convertendo la risposta dell'utente in minuscolo o maioscolo

//risposta = Console.ReadLine().ToLower();
//risposta = Console.ReadLine().ToUpper();

Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;

List<int> tentativiUtente = new List<int>();

string risposta = "s"; //inizializzo la risposta "s" per far partire il gioco

do
{
    int scelta = 0;

    do{
        Console.WriteLine("Scegli il livello di difficolta':");
        Console.WriteLine("1. Facile (1-50, 10 tentativi)");
        Console.WriteLine("2. Medio (1-100, 7 tentativi)");
        Console.WriteLine("3. Difficile (1-200, 5 tentativi)");


        bool successoLivelloDifficolta = int.TryParse(Console.ReadLine(), out scelta); // TryParse restituisce true se la conversione è riuscita, altrimenti false

        // se la conversione non è riuscita oppure la scelta non è compresa tra 1 e 3
        if (!successoLivelloDifficolta || scelta < 1 || scelta > 3)
        {
            Console.WriteLine("Scelta non valida."); // Stampo un messaggio di errore
        }
    }while (scelta < 1 || scelta > 3);

        switch (scelta)
        {
            case 1:
                numeroDaIndovinare = random.Next(1, 51);
                punteggio = 100;
                tentativi = 10;
                break;
            case 2:
                numeroDaIndovinare = random.Next(1, 101);
                punteggio = 100;
                tentativi = 7;
                break;
            case 3:
                numeroDaIndovinare = random.Next(1, 201);
                punteggio = 100;
                tentativi = 5;
                break;
            default:
                Console.WriteLine("Scelta non valida.");
                break;
        }

        Console.WriteLine("Indovina il numero. Punteggio massimo: 100 punti.");

        while (!haIndovinato && tentativi > 0)
        {
            Console.Write("Tentativo: ");
            bool successo = int.TryParse(Console.ReadLine(), out numeroUtente); // TryParse restituisce true se la conversione è riuscita, altrimenti false

            if (!successo)
            {
                Console.WriteLine("Inserisci un numero valido."); // Se l'utente non ha inserito un numero valido, si salta il tentativo
                continue; // Salta il resto del ciclo e va al prossimo tentativo
            }

            tentativiUtente.Add(numeroUtente);
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

        foreach (int tentativo in tentativiUtente)
        {
            Console.Write($"{tentativo} ");
        }
        
        Console.WriteLine("Vuoi giocare di nuovo? (s/n)");
        risposta = Console.ReadLine();

        while(risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
        {
            Console.WriteLine("Risposta non valida. Vuoi giocare di nuovo? (s/n)");
            risposta = Console.ReadLine();
        }

        haIndovinato = false; // resetto la variabile haIndovinato
        tentativiUtente.Clear(); // Cancello i tentativi effettuati

} while (risposta == "s" || risposta == "S");


```

### Comandi versionamento

```bash
git add --all
git commit -m "Indovina numero: Versione 9"
git push -u origin main
```

## Versione 10

**Obiettivo:**

Pulizia console usa `Console.Clear()` per pulire la console tra un gioco e l'altro e tra un tentativo e l'altro per rendere il gioco più pulito.

**Istruzioni:**

- Aggiungi `Console.Clear()` all'inizio del gioco per pulire la console prima di iniziare.
- Aggiungi `Console.Clear()` alla fine del ciclo del gioco per pulire la console tra un gioco e l'altro.
- Aggiungi `Console.Clear()` dopo ogni tentativo per pulire la console tra un tentativo e l'altro.

>**Esempio codice:**

```csharp

// possiamo evitare la confusione tra lettere maiuscole e minuscole (S s , N n) convertendo la risposta dell'utente in minuscolo o in maiuscolo cosi
// risposta = Console.ReadLine().ToLower(); // converto la risposta in minuscolo
// risposta = Console.ReadLine().ToUpper(); // converto la risposta in maiuscolo
Console.Clear();
Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;

List<int> tentativiUtente = new List<int>(); // creo una lista per memorizzare i tentativi

string risposta = "s"; // inizializzo la risposta a "s" per far partire il gioco

do
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

    switch (scelta)
    {
        case 1:
            numeroDaIndovinare = random.Next(1, 51);
            punteggio = 100;
            tentativi = 10;
            break;
        case 2:
            numeroDaIndovinare = random.Next(1, 101);
            punteggio = 100;
            tentativi = 7;
            break;
        case 3:
            numeroDaIndovinare = random.Next(1, 201);
            punteggio = 100;
            tentativi = 5;
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

        tentativiUtente.Add(numeroUtente);
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

    foreach (int tentativo in tentativiUtente)
    {
        Console.Write($"{tentativo} ");
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
    haIndovinato = false; // resetto la variabile haIndovinato
    tentativiUtente.Clear(); // cancello i tentativi effettuati

} while (risposta == "s" || risposta == "S");
```

### Comandi versionamento

```bash
git add --all
git commit -m "Indovina numero: Versione 10"
git push -u origin main
```