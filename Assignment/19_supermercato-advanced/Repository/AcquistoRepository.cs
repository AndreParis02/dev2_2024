using Newtonsoft.Json;

public class AcquistoRepository
{
    private readonly string folderPath = "Data/Acquisti";

    public void SalvaAcquisti(List<Acquisto> acquisti)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        foreach (var acquisto in acquisti)
        {
            string filePath = Path.Combine(folderPath, $"{acquisto.ID}.json");
            string jsonData = JsonConvert.SerializeObject(acquisto, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"acquisto salvato in {filePath}:\n{jsonData}\n");
        }
    }

    public List<Acquisto> CaricaAcquisti()
    {
        List<Acquisto> acquisti = new List<Acquisto>();
        if (Directory.Exists(folderPath))
        {
            foreach (var file in Directory.GetFiles(folderPath, "*.json"))
            {
                string readJsonData = File.ReadAllText(file);
                Acquisto acquisto = JsonConvert.DeserializeObject<Acquisto>(readJsonData);
                acquisti.Add(acquisto);
            }
        }
        return acquisti;
    }
}