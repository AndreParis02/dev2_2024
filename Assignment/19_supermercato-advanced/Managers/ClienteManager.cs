
public class ClienteManager
{
    // Lista di clienti di tipo Cliente per memorizzare i clienti
    private List<Cliente> clienti;

    // Oggetto di tipo ClienteRepository per salvare i dati su file
    private ClienteRepository repository;

    // variabile prossimo Id
    private int prossimoId;

    // Modifica il costruttore per inizializzare prossimoId con il valore piu alto di ID + 1:
    public ClienteManager(List<Cliente> Clienti)
    {
        clienti = Clienti;
        repository = new ClienteRepository();

        prossimoId = 1; // ID iniziale di default
        // Trova il prossimo ID disponibile
        foreach (var cliente in clienti)
        {
            if (cliente.ID >= prossimoId)
            {
                prossimoId = cliente.ID + 1;
            }
        }
    }

    public void AggiungiCliente(Cliente cliente)
    {
        // Assegna automaticamente un ID univoco
        cliente.ID = prossimoId;
        // Incrementa il prossimo ID per il prossimo cliente
        prossimoId++;
        clienti.Add(cliente);
        Console.WriteLine($"Cliente aggiunto con ID: {cliente.ID}");
    }

    public List<Cliente> OttieniClienti()
    {
        return clienti;
    }

    public void StampaClientiIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
            $"{"ID",-5} {"Username",-20} {"Credito",-10} {"Carrello",-20} {"StoricoAcquisti",-20}"
        );
        Console.WriteLine(new string('-', 50)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var cliente in clienti)
        {
            string carrello = cliente.Carrello.Count.ToString();
            string storicoAcquisti = cliente.StoricoAcquisti.Count.ToString();

            Console.WriteLine($"{cliente.ID,-5} {cliente.Username,-20} {cliente.Credito,-10} {carrello,-10} {storicoAcquisti,-15}");
        }
    }

    public Cliente TrovaClienteID(int id)
    {
        foreach (var cliente in clienti)
        {
            if (cliente.ID == id)
            {
                return cliente;
            }
        }
        return null;
    }

    public Cliente TrovaClienteNome(string Username)
    {
        foreach (var cliente in clienti)
        {
            if (cliente.Username == Username)
            {
                return cliente;
            }
        }
        return null;
    }

    public void AggiornaCliente(int id, Cliente nuovoCliente)
    {
        var cliente = TrovaClienteID(id);
        if (cliente != null)
        {
            cliente.Username = nuovoCliente.Username;
            cliente.Credito = nuovoCliente.Credito;
            cliente.Carrello = nuovoCliente.Carrello;
            cliente.StoricoAcquisti = nuovoCliente.StoricoAcquisti;


        }
    }

    public void EliminaCliente(int id)
    {
        var cliente = TrovaClienteID(id);
        if (cliente != null)
        {
            clienti.Remove(cliente);
            // elimina il file JSON corrispondente al cliente
            string filePath = Path.Combine("Data/Clienti", $"{id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Cliente eliminato: {filePath}");
        }
    }

    public void SalvaCliente()
    {
        repository.SalvaClienti(clienti);
    }  
}



