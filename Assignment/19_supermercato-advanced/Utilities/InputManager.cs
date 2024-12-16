public static class InputManager
{
    // classe di gestione degli input (InputManager) che può essere integrata per semplificare e standardizzare l'acquisizione e la validazione degli input
    // dell'utente. Questa classe aiuta a gestire i casi di errore e fornisce metodi per acquisire input di diversi tipi.
    // uso int-MinValue ed int.MaxValue per dare dei valori di default
    // Quando chiami il metodo, puoi specificare solo i valori che ti interessano e ignorare gli altri
    // Quando chiami il metodo con un solo valore (ad esempio 0 per min), non devi preoccuparti di specificare anche max se non è necessario
    // come succede con il random che non ha un valore min prende 0 di default
    // es int risultato = InputManager.LeggiIntero("Inserisci un valore: ", 0);

    // il metodo LeggiIntero accetta un messaggio da visualizzare all'utente e un intervallo di valori interi consentiti
    // MinValue ed MaxValue sono i metodi di int che rappresentano il valore minimo e massimo di un intero
    public static int LeggiIntero(string messaggio, int min = int.MinValue, int max = int.MaxValue)
    {
        int valore; // variabile per memorizzare il valore intero acquisito
                    // while che continua finche l'utente non fornisce un input valido
        while (true)
        {
            Console.Write($"{messaggio} "); // messaggio e la variabile di input che dovro passare al metodo
            string input = Console.ReadLine(); // acquisire l'input dell'utente come stringa
            // try parse per convertire la stringa in un intero e controllare se l'input è valido
            if (int.TryParse(input, out valore) && valore >= min && valore <= max) // devo verificarte se il valore e tra min e max e se e un intero
            {
                return valore; // restituire il valore intero se è valido
            }
            else
            {
                Console.WriteLine($"Inserire un valore intero compreso tra {min} e {max}."); // messaggio di errore
            }
        }
    }

    public static decimal LeggiDecimale(string messaggio, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
    {
        decimal valore; // variabile per memorizzare il valore decimale acquisito
        while (true)
        {
            Console.Write($"{messaggio} ");
            string input = Console.ReadLine();

            // sostituisco il punto con la virgola se l'input contiene il punto
            if (input.Contains(".")) // se l'input contiene la virgola e non contiene il punto
            {
                input = input.Replace(".", ","); // sostituire la virgola con il punto
            }

            // try parse per convertire la stringa in un decimale e controllare se l'input è valido
            if (decimal.TryParse(input, out valore) && valore >= min && valore <= max)
            {
                return valore;
            }
            Console.WriteLine($"Errore: Inserire un numero decimale compreso tra {min} e {max}.");
        }
    }

    public static string LeggiStringa(string messaggio, bool obbligatorio = true)
    {
        while (true)
        {
            Console.Write($"{messaggio} "); // messaggio e la variabile di input che dovro passare al metodo
            string input = Console.ReadLine(); // acquisire l'input dell'utente come stringa
            if (!string.IsNullOrWhiteSpace(input) || !obbligatorio) // se l'input non e vuoto o non e obbligatorio
            {
                return input; // restituire il valore della stringa
            }
            Console.WriteLine("Errore: Il valore non può essere vuoto."); // messaggio di errore
        }
    }

    public static bool LeggiConferma(string messaggio)
    {
        while (true)
        {
            Console.Write($"{messaggio} (s/n): ");
            string input = Console.ReadLine().ToLower();
            if (input == "s" || input == "si")
            {
                return true;
            }
            if (input == "n" || input == "no")
            {
                return false;
            }
            Console.WriteLine("Errore: Rispondere con 's' o 'n'.");
        }
    }
}