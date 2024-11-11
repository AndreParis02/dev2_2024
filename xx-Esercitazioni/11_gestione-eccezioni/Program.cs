//Gestione delle eccezioni

/*
La gestione delle eccezioni è un meccanismo che permette di gestire gli errori
che si verificano durante l'esecuzione di un programma.

è possigile usare il try parse però l'eccezione non viene gestita ma notificata all'utente

Ci sono diversi tipi di costrutto per la gestione delle eccezioni in C#:
- Try-catch
- Try-catch-finally
*/
/*
int number = int.Parse("abc");

//è possibile gestire l'errore di conversione

try
{
    int number2 = int.Parse("abc");
}catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
}

//è possibile gestire più tipi di eccezioni

try
{
    int number3 = int.Parse("abc");
}catch(FormatException e)
{
    Console.WriteLine($"Errore di formato:  {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
}

//è possibile usare il blocco try catch finally oer eseguire un blocco di codice anche se 
//si verifica un errore


try
{
int number4 = int.Parse("3");
}
catch (FormatException e)
{
    Console.WriteLine($"Errore di formato: {e.Message}");
}
catch (Exception e)
{
     Console.WriteLine($"Errore: {e.Message}");
}
finally
{
     Console.WriteLine("il Blocco finally viene sempre eseguito");
}

// è possibile lanciare un eccezione con il comando throw

try
{
    throw new Exception("Errore genetrico");
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
}

//esempio completo di gestione delle eccezioni con try-catch throw e finally
*/
try
{
    int number5 = int.Parse("3");
    //uso il throw
    throw new Exception("Errore genetrico");  
}
catch (FormatException e)
{
    Console.WriteLine($"Errore di formato: {e.Message}");
    //esempio di HResult
    Console.WriteLine($"Codice errore: {e.HResult}");
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
}
finally
{
     Console.WriteLine("Il blocco finally viene sempre eseguito");
}

/*
La principale differenza tra TryParse e TryCatch è che TryParse non genera un eccezione 
ma restituisce un valore booleano che indica se la conversione è riuscita o meno.
Tryparse è più veloce di TryCatch  perchè non genera un'eccezione.
è possibile usare il throw per lanciare un eccezione personalizzata.
*/

// esempi di gestione  delle eccezioni
//Il programma per deve avere un file txt con il nome "file.txt" e deve contenere un numero

try
{
    string text = File.ReadAllText("file.txt");
    int number6 = int.Parse(text);
}
catch (FileNotFoundException e)
{
    Console.WriteLine($"File non trovato: {e.Message}");
}
catch (FormatException e)
{
    Console.WriteLine($"Errore di formato: {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
}
finally
{
     Console.WriteLine("Il blocco finally viene sempre eseguito");
}

//il programma accede ad un elemento di un array non esistente

try
{
    int[] numbers = {1,2,3};
    Console.WriteLine(numbers[2]);
}
catch (IndexOutOfRangeException e)
{
    Console.WriteLine($"Indice non valido: {e.Message}");
}
catch (FormatException e)
{
    Console.WriteLine($"Errore di formato: {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
}
finally
{
     Console.WriteLine("Il blocco finally viene sempre eseguito");
}

//il programma accede ad un oggetto NULL

try
{
    string text2 = null;
    Console.WriteLine(text2.Length);
}
catch (NullReferenceException e)
{
    Console.WriteLine($"Oggetto null: {e.Message}");
        // esempio di e.HResult
    Console.WriteLine($"Codice errore: {e.HResult}");
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
    Console.WriteLine("Errore: oggetto null");
}
finally
{
     Console.WriteLine("Il blocco finally viene sempre eseguito");
}

// il programma tenta di dividere per 0

try
{
    int number7 = 10;
    int number8 = 0;
    int result = number7/number8;
}
catch (DivideByZeroException e)
{
    Console.WriteLine($"Divisione per zero: {e.Message}");
    //esempio di HResult
    Console.WriteLine($"Codice errore: {e.HResult}");
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
}
finally
{
     Console.WriteLine("Il blocco finally viene sempre eseguito");
}

//Il programma tenta di accedere ad un argomento fuori dal range consentito

try
{
    int number9 = int.Parse("100000000000");
}
catch (OverflowException e)
{
    Console.WriteLine($"Overflow: {e.Message}");
    //esempio di HResult
    Console.WriteLine($"Codice errore: {e.HResult}");
}
catch (Exception e)
{
    Console.WriteLine($"Errore: {e.Message}");
}
finally
{
     Console.WriteLine("Il blocco finally viene sempre eseguito");
}