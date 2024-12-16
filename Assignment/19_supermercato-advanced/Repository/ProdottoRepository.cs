using Newtonsoft.Json;

public class ProdottoRepository
{
    private readonly string folderPath = "Data/Prodotti";

    public void SalvaProdotti(List<Prodotto> prodotti)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        foreach (var prodotto in prodotti)
        {
            string filePath = Path.Combine(folderPath, $"{prodotto.ID}.json");
            string jsonData = JsonConvert.SerializeObject(prodotto, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"Prodotto salvato in {filePath}:\n{jsonData}\n");
        }
    }

    public List<Prodotto> CaricaProdotti()
    {
        List<Prodotto> prodotti = new List<Prodotto>();
        if (Directory.Exists(folderPath))
        {
            foreach (var file in Directory.GetFiles(folderPath, "*.json"))
            {
                string readJsonData = File.ReadAllText(file);
                Prodotto prodotto = JsonConvert.DeserializeObject<Prodotto>(readJsonData);
                prodotti.Add(prodotto);
            }
        }
        return prodotti;
    }
}