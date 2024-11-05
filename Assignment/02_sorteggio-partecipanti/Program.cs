Random random = new Random();

List<string> partecipanti = new List<string>() {"Andrea", "Anita", "Ivan", "Diego", "Sofia", "Giorgio", "Felipe", "Tamer" }; 
Dictionary<string, List<String>> squadre = new Dictionary<string, List<String>>();
int numeroSorteggiato;

int nSquadre = 0;
int nComponenti = 0;


partecipanti.Sort(); // ordina gli elementi di partecipanti

string risposta = "s"; 
Console.WriteLine(partecipanti.Count);
Console.WriteLine("Inserisci il numero di squadre: ");
nSquadre = Console.Read();


if((partecipanti.Count % nSquadre) == 0)
{
    nComponenti = partecipanti.Count / nSquadre;
}
string[] squadra1 = new string[nComponenti];
    do
    {
        if(partecipanti.Count > 0)
        {
            for(int i = 0;i < nComponenti;i++)
            {
                numeroSorteggiato = random.Next(0, partecipanti.Count);
                squadre.Add;
                partecipanti.RemoveAt(numeroSorteggiato);
            }

            

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
