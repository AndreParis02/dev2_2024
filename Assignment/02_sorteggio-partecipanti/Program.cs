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
