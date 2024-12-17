
public class RuoloManager
{
    // Lista di ruoli di tipo Ruoli per memorizzare i ruoli
    private List<Ruolo> ruoli;

    // Oggetto di tipo RuoliRepository per salvare i dati su file
    private RuoloRepository repository;

    // variabile prossimo Id
    private int prossimoId;

    // Modifica il costruttore per inizializzare prossimoId con il valore piu alto di ID + 1:
    public RuoloManager(List<Ruolo> Ruoli)
    {
        ruoli= Ruoli;
        repository = new RuoloRepository();

        prossimoId = 1; // ID iniziale di default
        // Trova il prossimo ID disponibile
        foreach (var ruolo in Ruoli)
        {
            if (ruolo.ID >= prossimoId)
            {
                prossimoId = ruolo.ID + 1;
            }
        }
    }

    public void AggiungiRuolo(Ruolo ruolo)
    {
        // Assegna automaticamente un ID univoco
        ruolo.ID = prossimoId;
        // Incrementa il prossimo ID per il prossimo ruolo
        prossimoId++;
        ruoli.Add(ruolo);
        Console.WriteLine($"Ruolo aggiunto con ID: {ruolo.ID}");
    }

    public List<Ruolo> OttieniRuoli()
    {
        return ruoli;
    }

    public void StampaRuoliIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
            $"{"ID",-5} {"Nome",-10}"
        );
        Console.WriteLine(new string('-', 20)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var ruolo in ruoli)
        {
            Console.WriteLine(
                $"{ruolo.ID,-5} {ruolo.ruolo,-10}"
            );
        }
    }


    public Ruolo TrovaRuolo(int id)
    {
        foreach (var ruolo in ruoli)
        {
            if (ruolo.ID == id)
            {
                return ruolo;
            }
        }
        return null;
    }

    public void AggiornaRuolo(int id, Ruolo nuovoRuolo)
    {
        var ruolo = TrovaRuolo(id);
        if (ruolo != null)
        {
            ruolo.ruolo = nuovoRuolo.ruolo;
        }
    }

    public void EliminaRuolo(int id)
    {
        var ruolo = TrovaRuolo(id);
        if (ruolo != null)
        {
            ruoli.Remove(ruolo);
            // elimina il file JSON corrispondente al ruolo
            string filePath = Path.Combine("Data/Ruoli", $"{id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Ruolo eliminata: {filePath}");
        }
    }

    public void SalvaRuolo()
    {
        repository.SalvaRuoli(ruoli);
    }
}
