
public class CategoriaManager
{
    // Lista di categorie di tipo Categorie per memorizzare i categorie
    private List<Categoria> categorie;

    // Oggetto di tipo CategorieRepository per salvare i dati su file
    private CategoriaRepository repository;

    // variabile prossimo Id
    private int prossimoId;

    // Modifica il costruttore per inizializzare prossimoId con il valore piu alto di ID + 1:
    public CategoriaManager(List<Categoria> Categorie)
    {
        categorie= Categorie;
        repository = new CategoriaRepository();

        prossimoId = 1; // ID iniziale di default
        // Trova il prossimo ID disponibile
        foreach (var categoria in Categorie)
        {
            if (categoria.ID >= prossimoId)
            {
                prossimoId = categoria.ID + 1;
            }
        }
    }

    public void AggiungiCategoria(Categoria categoria)
    {
        // Assegna automaticamente un ID univoco
        categoria.ID = prossimoId;
        // Incrementa il prossimo ID per il prossimo categoria
        prossimoId++;
        categorie.Add(categoria);
        Console.WriteLine($"Categoria aggiunto con ID: {categoria.ID}");
    }

    public List<Categoria> OttieniCategorie()
    {
        return categorie;
    }

    public void StampaCategorieIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
            $"{"ID",-5} {"Nome",-10}"
        );
        Console.WriteLine(new string('-', 20)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var categoria in categorie)
        {
            Console.WriteLine(
                $"{categoria.ID,-5} {categoria.Nome,-10}"
            );
        }
    }


    public Categoria TrovaCategoria(int id)
    {
        foreach (var categoria in categorie)
        {
            if (categoria.ID == id)
            {
                return categoria;
            }
        }
        return null;
    }

    public void AggiornaCategoria(int id, Categoria nuovoCategoria)
    {
        var categoria = TrovaCategoria(id);
        if (categoria != null)
        {
            categoria.Nome = nuovoCategoria.Nome;
        }
    }

    public void EliminaCategoria(int id)
    {
        var categoria = TrovaCategoria(id);
        if (categoria != null)
        {
            categorie.Remove(categoria);
            // elimina il file JSON corrispondente al categoria
            string filePath = Path.Combine("Data/Categorie", $"{id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Categoria eliminata: {filePath}");
        }
    }

    public void SalvaCategoria()
    {
        repository.SalvaCategorie(categorie);
    }
}
