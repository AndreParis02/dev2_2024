using System.Net;
using System.Net.Sockets; //using che da le funzionalità per la comunicazione di rete
using System.Text; //using che da le funzionalità per l gestione delle stringhe che vengono inviate e ricevute
using System.Threading; //unsing che da le funzionalità per la gestione dei thread cioè dei flussi di esecuzione separati

public class Server
{
    private TcpListener listener; //Oggetto che rappresenta un server TCP

    //creo la lista clients per memorizzare i client
    private List<TcpClient> clients = new List<TcpClient>(); //Lista per memorizzare i client connessi

    private object lockObject = new object(); //proprietà Lock per evitare problemi di concorrenza
    public void StartServer(int port)
    {
        listener = new TcpListener(IPAddress.Any, port); // IPAddress.Any indica che il server accetta connessioni su tutte le interfacce di rete
        listener.Start(); //Avvia il server
        Console.WriteLine($"Server avviato su porta {port}");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient(); //Accetta una connessione da un client e restituisce un oggetto TcpClient che rappresenta il client connesso
            lock (lockObject)
            {
                clients.Add(client);//Aggiunge un client alla lista
            }
            Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient)); //Crea un nuovo thread per gestire il client connesso
            clientThread.Start(client);
        }
    }

    private void HandleClient(object obj)
    {
        TcpClient client = (TcpClient)obj; //Converte l'oggetto passato come argomento in un oggetto TcpClient
        NetworkStream stream = client.GetStream(); //Ottiene il flusso di dati tra il client e il server networkstream
        byte[] buffer = new byte[1024];

        try
        {
            int byteCount;

            while ((byteCount = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string message = Encoding.ASCII.GetString(buffer, 0, byteCount); //converte i byte ricevuti in una stringa
                Console.WriteLine($"Messaggio ricevuto: {message}");
                Broadcast(message); //Invia il messaggio a tutti i client connessi
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Un client si è disconnesso.");
        }
        finally
        {
            lock (lockObject)
            {
                clients.Remove(client);
            }
            client.Close();
        }

    }

    //il metodo Broadcast si occupa di inviare un messaggio a tutti i client connessi
    private void Broadcast(string message)
    {
        foreach (TcpClient client in clients) // Per ogni client connesso
        {
            NetworkStream stream = client.GetStream(); //Ottiene il flusso di dati tra client e il server
            byte[] buffer = Encoding.ASCII.GetBytes(message); //Converte la stringa in un array di byte
            stream.Write(buffer, 0, buffer.Length); //Invia il messaggio al client
        }
    }

    public static void Main(string[] args) //Metodo Main che viene eseguito all'avvio del programma
    {
        Server server = new Server(); //Crea un'istanza della classe Server
        server.StartServer(3000); // Avvia il server sulla porta 3000
    }
}