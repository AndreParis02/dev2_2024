using System.Data.SQLite;

class Database
{
    private SQLiteConnection _connection;    // Connessione al db che è private perchè non deve essere accessibile dall'esterno
                                            //utilizziamo l'underscore davanti al nome in modo da indicare che è una variabile privata 
    public Database() //costruttore della classe db
    {
        _connection = new SQLiteConnection("Data Source=database.db"); //Creazione di una connessione al db
        _connection.Open(); //Apertura della connessione
        var command = new SQLiteCommand ("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)", _connection); // creazione della tabella users
        command.ExecuteNonQuery(); //Esecuzione del comando
    }

    public void AddUser(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection); //Creazione di un comando per inserire un nuovo utente
        command.ExecuteNonQuery(); //esecuzione del comando
    }

    public List<string> GetUsers() //metodo GetUsers che serve per ottenere la lista degli utenti
    {
        var command = new SQLiteCommand("SELECT name FROM users", _connection); // Creazione di un oggetto per leggere i risultati
        var reader = command.ExecuteReader(); // Esecuzione del comando e creazione di un oggetto per leggere i risultati cosi abbiamo caricato i dati nel reader
        var users = new List<string>(); //Creazione di una lista per memorizzaree i nomi degli utenti
        while (reader.Read())
        {
            users.Add(reader.GetString(0)); // Aggiunta del nome dell'utente alla lista
                                            //utilizzo (0) perchè il nome è il primo campo 
        }
        return users; //Restituzione della lista degli utenti
    }

    public void CloseConnection()
    {
        if  (_connection.State != System.Data.ConnectionState.Closed)
        {
            _connection.Close();
        }
    }
}