using Newtonsoft.Json;

public class RuoloRepository
{
    private readonly string folderPath = "Data/Ruoli";

    public void SalvaRuoli(List<Ruolo> ruoli)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        foreach (var ruolo in ruoli)
        {
            string filePath = Path.Combine(folderPath, $"{ruolo.ID}.json");
            string jsonData = JsonConvert.SerializeObject(ruolo, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"ruolo salvato in {filePath}:\n{jsonData}\n");
        }
    }

    public List<Ruolo> CaricaRuoli()
    {
        List<Ruolo> ruoli = new List<Ruolo>();
        if (Directory.Exists(folderPath))
        {
            foreach (var file in Directory.GetFiles(folderPath, "*.json"))
            {
                string readJsonData = File.ReadAllText(file);
                Ruolo ruolo = JsonConvert.DeserializeObject<Ruolo>(readJsonData);
                ruoli.Add(ruolo);
            }
        }
        return ruoli;
    }
}