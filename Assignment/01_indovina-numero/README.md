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