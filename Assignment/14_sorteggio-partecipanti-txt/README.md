# Sotreggio partecipanti con salvataggio su txt

## Obiettivo

- Creare un applicazione csharp che permetta di:
- Sorteggiare i partecipanti da una lista di nomi presi da un file txt.
- I nomi sorteggiati devono essere salvati su un file txt di output.
- Il programma chiede all'utente quanti nomi sorteggiare

```csharp
Random random = new Random();

List<string> partecipanti = new List<string>();
List<string> estratti = new List<string>();

Console.WriteLine("Quante persone vuoi sorteggiare?");
string inputSorteggio = Console.ReadLine();
int nPersoneDaSorteggiare = Convert.ToInt32(inputSorteggio);

string path = @"PartecipantiDaEstrarre.txt";
string path2 = @"Estrazione.txt";

string[] partecipante = File.ReadAllLines(path);

foreach(string p in partecipante)
{
    
    Console.WriteLine(p); //stampa la riga 
    partecipanti.Add(p);
}

int numeroSorteggiato;

partecipanti.Sort(); // ordina gli elementi di partecipanti

for(int i = 0;i< nPersoneDaSorteggiare; i++)
{
    if (partecipanti.Count > 0)
    {
        numeroSorteggiato = random.Next(0, partecipanti.Count);

        Console.WriteLine($"Il nome estratto è: {partecipanti[numeroSorteggiato]}");
        estratti.Add(partecipanti[numeroSorteggiato]);

        File.WriteAllText(path2, partecipanti[numeroSorteggiato]);
        

        partecipanti.RemoveAt(numeroSorteggiato);
    }     
}
    File.WriteAllLines(path2, estratti);

```