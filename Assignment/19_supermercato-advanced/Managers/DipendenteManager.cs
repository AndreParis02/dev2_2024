
public class DipendenteManager
{
    // Lista di dipendenti di tipo Dipendente per memorizzare i dipendenti
    private List<Dipendente> dipendenti;

    // Oggetto di tipo DipendenteRepository per salvare i dati su file
    private DipendenteRepository repository;

    // variabile prossimo Id
    private int prossimoId;

    // Modifica il costruttore per inizializzare prossimoId con il valore piu alto di ID + 1:
    public DipendenteManager(List<Dipendente> Dipendenti)
    {
        dipendenti = Dipendenti;
        repository = new DipendenteRepository();

        prossimoId = 1; // ID iniziale di default
        // Trova il prossimo ID disponibile
        foreach (var dipendente in dipendenti)
        {
            if (dipendente.ID >= prossimoId)
            {
                prossimoId = dipendente.ID + 1;
            }
        }
    }

    public void AggiungiDipendente(Dipendente dipendente)
    {
        // Assegna automaticamente un ID univoco
        dipendente.ID = prossimoId;
        // Incrementa il prossimo ID per il prossimo ipendente
        prossimoId++;
        dipendenti.Add(dipendente);
        Console.WriteLine($"Dipendente aggiunto con ID: {dipendente.ID}");
    }

    public List<Dipendente> OttieniDipendenti()
    {
        return dipendenti;
    }

    public void StampaDipendentiIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
            $"{"ID",-5} {"Username",-20} {"Ruolo",-10}"
        );
        Console.WriteLine(new string('-', 35)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var dipendente in dipendenti)
        {
            Console.WriteLine(
                $"{dipendente.ID,-5} {dipendente.Username,-20} {dipendente.Ruolo,-10}"
            );
        }
    }


    public Dipendente TrovaDipendente(int id)
    {
        foreach (var dipendente in dipendenti)
        {
            if (dipendente.ID == id)
            {
                return dipendente;
            }
        }
        return null;
    }

    public void AggiornaDipendente(int id, Dipendente nuovoDipendente)
    {
        var dipendente = TrovaDipendente(id);
        if (dipendente != null)
        {
            dipendente.Username = nuovoDipendente.Username;
            dipendente.Ruolo = nuovoDipendente.Ruolo;     


        
        }
    }

    public void EliminaDipendente(int id)
    {
        var dipendente = TrovaDipendente(id);
        if (dipendente != null)
        {
            dipendenti.Remove(dipendente);
            // elimina il file JSON corrispondente al dipendente
            string filePath = Path.Combine("Data/Dipendenti", $"{id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Dipendente eliminato: {filePath}");
        }
    }

    public void SalvaDipendente()
    {
        repository.SalvaDipendenti(dipendenti);
    }
}
