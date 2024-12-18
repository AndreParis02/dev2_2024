public class ProdottoManager
{
    // Lista di prodotti di tipo Prodotto per memorizzare i prodotti
    private List<Prodotto> prodotti;

    // Oggetto di tipo ProdottoRepository per salvare i dati su file
    private ProdottoRepository repository;

    // variabile prossimo Id
    private int prossimoId;

    // Modifica il costruttore per inizializzare prossimoId con il valore piu alto di ID + 1:
    public ProdottoManager(List<Prodotto> Prodotti)
    {
        prodotti = Prodotti;
        repository = new ProdottoRepository();

        prossimoId = 1; // ID iniziale di default
        // Trova il prossimo ID disponibile
        foreach (var prodotto in prodotti)
        {
            if (prodotto.ID >= prossimoId)
            {
                prossimoId = prodotto.ID + 1;
            }
        }
    }

    public void AggiungiProdotto(Prodotto prodotto)
    {
        // Assegna automaticamente un ID univoco
        prodotto.ID = prossimoId;
        // Incrementa il prossimo ID per il prossimo prodotto
        prossimoId++;
        prodotti.Add(prodotto);
        Console.WriteLine($"Prodotto aggiunto con ID: {prodotto.ID}");
    }

    public List<Prodotto> OttieniProdotti()
    {
        return prodotti;
    }

    // Ogni campo utilizza il formato {Campo,-Larghezza} dove:
    // Campo è il valore da stampare
    // -Larghezza specifica la larghezza del campo; il segno - allinea il testo a sinistra.
    //{"Nome",-20} significa che il nome del prodotto avrà una larghezza fissa di 20 caratteri, allineato a sinistra
    // Formato dei numeri:
    // Per i prezzi, viene usato il formato 0.00 per mostrare sempre due cifre decimali
    // Linea separatrice:
    // La riga Console.WriteLine(new string('-', 50)); stampa una linea divisoria lunga 50 caratteri per migliorare la leggibilità
    public void StampaProdottiIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
            $"{"ID",-5} {"Nome",-20} {"Prezzo",-10} {"Giacenza",-10} {"Categoria",-10}"
        );
        Console.WriteLine(new string('-', 50)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var prodotto in prodotti)
        {
            Console.WriteLine(
                $"{prodotto.ID,-5} {prodotto.Nome,-20} {prodotto.Prezzo,-10:0.00} {prodotto.Giacenza,-10} {prodotto.categoria.Nome,-10}"
            );
        }
    }

    public Prodotto TrovaProdotto(int id)
    {
        foreach (var prodotto in prodotti)
        {
            if (prodotto.ID == id)
            {
                return prodotto;
            }
        }
        return null;
    }

    public void AggiornaProdotto(int id, Prodotto nuovoProdotto)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotto.Nome = nuovoProdotto.Nome;
            prodotto.Prezzo = nuovoProdotto.Prezzo;
            prodotto.Giacenza = nuovoProdotto.Giacenza;
            prodotto.categoria = nuovoProdotto.categoria;
        }
    }

    public void EliminaProdotto(int id)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotti.Remove(prodotto);
            // elimina il file JSON corrispondente al prodotto
            string filePath = Path.Combine("Data/Prodotti", $"{id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Prodotto eliminato: {filePath}");
        }
    }

    public void SalvaProdotti()
    {
        repository.SalvaProdotti(prodotti);
    }
}