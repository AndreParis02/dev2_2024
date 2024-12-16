using Newtonsoft.Json;

public class CategoriaRepository
{
    private readonly string folderPath = "Data/Categorie";

    public void SalvaCategorie(List<Categoria> categorie)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        foreach (var categoria in categorie)
        {
            string filePath = Path.Combine(folderPath, $"{categoria.ID}.json");
            string jsonData = JsonConvert.SerializeObject(categoria, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"categoria salvato in {filePath}:\n{jsonData}\n");
        }
    }

    public List<Categoria> CaricaCategorie()
    {
        List<Categoria> categorie = new List<Categoria>();
        if (Directory.Exists(folderPath))
        {
            foreach (var file in Directory.GetFiles(folderPath, "*.json"))
            {
                string readJsonData = File.ReadAllText(file);
                Categoria categoria = JsonConvert.DeserializeObject<Categoria>(readJsonData);
                categorie.Add(categoria);
            }
        }
        return categorie;
    }
}