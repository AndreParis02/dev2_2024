
public class AcquistoManager
{
    // Lista di acquisti di tipo Acquisti per memorizzare i acquisti
    private List<Acquisto> acquisti;

    // Oggetto di tipo AcquistiRepository per salvare i dati su file
    private AcquistoRepository repository;

    // variabile prossimo Id
    private int prossimoId;

    // Modifica il costruttore per inizializzare prossimoId con il valore piu alto di ID + 1:
    public AcquistoManager(List<Acquisto> Acquisti)
    {
        acquisti= Acquisti;
        repository = new AcquistoRepository();

        prossimoId = 1; // ID iniziale di default
        // Trova il prossimo ID disponibile
        foreach (var acquisto in Acquisti)
        {
            if (acquisto.ID >= prossimoId)
            {
                prossimoId = acquisto.ID + 1;
            }
        }
    }

    public void AggiungiAcquisto(Acquisto acquisto)
    {
        // Assegna automaticamente un ID univoco
        acquisto.ID = prossimoId;
        // Incrementa il prossimo ID per il prossimo acquisto
        prossimoId++;
        acquisti.Add(acquisto);
        Console.WriteLine($"Acquisto aggiunto con ID: {acquisto.ID}");
    }

    public List<Acquisto> OttieniAcquisti()
    {
        return acquisti;
    }

    public void StampaAcquistiIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
            $"{"ID",-5} {"cliente",-10} {"prodotti", -20} {"quantita", -5} {"data", -10} {"stato", -5}"
        );
        Console.WriteLine(new string('-', 20)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var acquisto in acquisti)
        {
            Console.WriteLine(
                $"{acquisto.ID,-5} {acquisto.Cliente,-10} {acquisto.prodotti, -20} {acqusito.quantita, -5} {acquisto.data, -10} {acquisto.stato, -5}"
            );
        }
    }


    public Acquisto TrovaAcquisto(int id)
    {
        foreach (var acquisto in acquisti)
        {
            if (acquisto.ID == id)
            {
                return acquisto;
            }
        }
        return null;
    }

    public void AggiornaAcquisto(int id, Acquisto nuovoAcquisto)
    {
        var acquisto = TrovaAcquisto(id);
        if (acquisto != null)
        {
            acquisto.Nome = nuovoAcquisto.Nome;
        }
    }

    public void EliminaAcquisto(int id)
    {
        var acquisto = TrovaAcquisto(id);
        if (acquisto != null)
        {
            acquisti.Remove(acquisto);
            // elimina il file JSON corrispondente al acquisto
            string filePath = Path.Combine("Data/Acquisti", $"{id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Acquisto eliminata: {filePath}");
        }
    }

    public void SalvaAcquisto()
    {
        repository.SalvaAcquisti(acquisti);
    }
}
