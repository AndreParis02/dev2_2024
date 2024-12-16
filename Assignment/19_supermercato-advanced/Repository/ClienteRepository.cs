using Newtonsoft.Json;

public class ClienteRepository
{
    private readonly string folderPath = "Data/Clienti";

    public void SalvaClienti(List<Cliente> clienti)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        foreach (var cliente in clienti)
        {
            string filePath = Path.Combine(folderPath, $"{cliente.ID}.json");
            string jsonData = JsonConvert.SerializeObject(cliente, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"cliente salvato in {filePath}:\n{jsonData}\n");
        }
    }

    public List<Cliente> CaricaClienti()
    {
        List<Cliente> clienti = new List<Cliente>();
        if (Directory.Exists(folderPath))
        {
            foreach (var file in Directory.GetFiles(folderPath, "*.json"))
            {
                string readJsonData = File.ReadAllText(file);
                Cliente cliente = JsonConvert.DeserializeObject<Cliente>(readJsonData);
                clienti.Add(cliente);
            }
        }
        return clienti;
    }
}