# Calcolatrice semplice

## Versione 1

## Obiettivo

- Scrivere un programma che simuli una calcolatrice semplice.
- L'utente deve poter inserire due numeri e selezionare un operatore matematico (+, -, *, /)
- il programma deve eseguire l'operazione selezionata e stampare il risultato.
- Il programma non gestisce nessun tipo di errore o di eccezione.

```csharp
int numero1;
int numero2;
int Result = 0;
int scelta = 0;

// pulisco la console
Console.Clear();

Console.WriteLine("Benvenuto nella calcolatrice semplice");

Console.WriteLine("Inserisci il primo numero: ");
int.TryParse(Console.ReadLine(), out numero1);

Console.WriteLine("Inserisci il secondo numero: ");
int.TryParse(Console.ReadLine(), out numero2);



Console.WriteLine("1. Somma (+)");
Console.WriteLine("2. Sottrazione (-)");
Console.WriteLine("3. Moltiplicazione (*)");
Console.WriteLine("4. Divisione (/)");

Console.WriteLine("Scegli l'operazione da svolgere:");
int.TryParse(Console.ReadLine(), out scelta);

// pulisco la console
Console.Clear();

switch (scelta)
    {
        case 1:
            Console.WriteLine("Hai scelto somma");
            Result = numero1 + numero2;
            break;

        case 2:
            Console.WriteLine("Hai scelto sottrazione");
            Result = numero1 - numero2;
            break;

        case 3:
            Console.WriteLine("Hai scelto moltiplicazione");
            Result = numero1 * numero2;
            break;

        case 4:
            Console.WriteLine("Hai scelto moltiplicazione");
            Result = numero1 / numero2;
        break;

        default:
            Console.WriteLine("Scelta non valida.");
            break;
    }


Console.WriteLine($"il risultato dell'operazione è: {Result}");
```

### Comandi versionamento

```bash
git add --all
git commit -m "Calcolatrice semplice: versione 1"
git push -u origin main
```