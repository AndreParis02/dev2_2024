Dictionary<string, Dictionary<string, string>> rubrica = new Dictionary<string, Dictionary<string, string>>();

bool continua = true;

// Menu principale
while (continua)
{
    Console.WriteLine("\nScegli un'opzione:");
    Console.WriteLine("1. Aggiungi un contatto alla rubrica");
    Console.WriteLine("2. Visualizza la rubrica");
    Console.WriteLine("3. cerca contatto per nome");
    Console.WriteLine("4. Rimuovi un contatto dalla rubrica");
    Console.WriteLine("0. Esci");

    Console.Write("\nFai la tua scelta: ");
    string scelta = Console.ReadLine();

    switch (scelta)
    {
        case "1":
            AddContatto(rubrica);
            break;
        case "2":
            VisualizzaRubrica(rubrica);
            break;
        case "3":
            CercaContatto(rubrica);
            break;
        case "4":
            RemoveContatto(rubrica);
            break;
   
        case "0":
            continua = false;
            break;
        default:
            Console.WriteLine("Scelta non valida. Riprova.");
            break;
    }
}

//--------------------funzione aggiunta contatto--------------------
static void AddContatto(Dictionary<string, Dictionary<string,string>> rubrica)
{ 
     
        Console.Write("Inserisci il nome del contatto: ");
        string nome = Console.ReadLine();

        if (rubrica.ContainsKey(nome))
        {
            Console.WriteLine("Il contatto esiste già.");
            return;
        }

        Console.Write("Inserisci il cognome: ");
        string cognome = Console.ReadLine();
        Console.Write("Inserisci l'indirizzo: ");
        string indirizzo = Console.ReadLine();
        Console.Write("Inserisci il numero di telefono: ");
        string numeroTelefono = Console.ReadLine();

        var contatto = new Dictionary<string, string>
        {
            { "Cognome", cognome },
            { "Indirizzo", indirizzo },
            { "NumeroTelefono", numeroTelefono }
        };

        rubrica[nome] = contatto;
        Console.WriteLine("Contatto aggiunto con successo!");
}


//--------------------funzione visualizza rubrica--------------------
static void VisualizzaRubrica(Dictionary<string, Dictionary<string,string>> rubrica)
{
    if (rubrica.Count == 0)
        {
            Console.WriteLine("La rubrica è vuota.");
            return;
        }

        foreach (var contatto in rubrica)
        {
            Console.WriteLine($"Nome: {contatto.Key}");
            Console.WriteLine($"Cognome: {contatto.Value["Cognome"]}");
            Console.WriteLine($"Indirizzo: {contatto.Value["Indirizzo"]}");
            Console.WriteLine($"Telefono: {contatto.Value["NumeroTelefono"]}");
            Console.WriteLine();
        }
}
        

//--------------------funzione cerca contatto--------------------
static void CercaContatto(Dictionary<string, Dictionary<string,string>> rubrica)
{
     Console.Write("Inserisci il nome del contatto da cercare: ");
        string nome = Console.ReadLine();

        if (rubrica.ContainsKey(nome))
        {
            var contatto = rubrica[nome];
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Cognome: {contatto["Cognome"]}");
            Console.WriteLine($"Indirizzo: {contatto["Indirizzo"]}");
            Console.WriteLine($"Telefono: {contatto["NumeroTelefono"]}");
        }
        else
        {
            Console.WriteLine("Contatto non trovato.");
        }

}

//--------------------funzione rimozione contatto--------------------
static void RemoveContatto(Dictionary<string, Dictionary<string,string>> rubrica)
{
    Console.Write("Inserisci il nome del contatto da cancellare: ");
        string nome = Console.ReadLine();

        if (rubrica.ContainsKey(nome))
        {
            rubrica.Remove(nome);
            Console.WriteLine("Contatto cancellato con successo.");
        }
        else
        {
            Console.WriteLine("Contatto non trovato.");
        }
}