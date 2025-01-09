using System.Data.SQLite;

//comando installazione pacchetto System.Data.SQLite
//dotnet add package System.Data.SQLite

string path = @"database.db"; //la rotta del file del database

if(!File.Exists(path)) //se il file del db non esiste
{
    SQLiteConnection.CreateFile(path); //crea il file del db

    //crea la connessione al db la versione 3 è un indicazione della versione del db e può essere personalizzata
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;");

    connection.Open(); //apre la connessione al Database

    string sql = @"
                CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0));
                INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('prodotto1', 1, 10);
                INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('prodotto2', 2, 20);
                INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('prodotto3', 3, 30);
                ";
    //oppure insert multiplo cosi
    //INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('prodotto1', 1, 10), ('prodotto2', 2, 20), ('prodotto3', 3, 30);

    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db
                                                                //sql è la stringa che contiene il comando sql
    command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al db nonquery significa che non si aspetta risultato

    connection.Close(); // chiude la connessione al db;
}

while(true)
{
    Console.WriteLine("");
    Console.WriteLine("1 - inserisci prodotto");
    Console.WriteLine("2 - visualizza prodotti");
    Console.WriteLine("3 - elimina prodotto");
    Console.WriteLine("4 - modifica prodotto");
    Console.WriteLine("0 - esci");
    Console.WriteLine("scegli un opzione: ");
    string scelta = Console.ReadLine();
    if (scelta == "1")
    {
        Console.Clear(); //pulisco la console
        InserisciProdotto();
    }
    else if (scelta == "2")
    {
        Console.Clear(); //pulisco la console
        VisualizzaProdotti();
    }
    else if (scelta == "3")
    {
        Console.Clear(); //pulisco la console
        VisualizzaProdotti();
        Console.WriteLine("");
        EliminaProdotto();
    }
    else if (scelta == "4")
    {
        Console.Clear(); //pulisco la console
        VisualizzaProdotti();
        Console.WriteLine("");
        ModificaProdotto();
    }
    else if (scelta == "0")
    {
        break;
    }
}

static void InserisciProdotto()
{
    Console.WriteLine("inserisci il nome del prodotto");
    string nome = Console.ReadLine();
    Console.WriteLine("inserisci il prezzo del prodotto");
    string prezzo = Console.ReadLine();
    Console.WriteLine("inserisci la quantità del prodotto");
    string quantita = Console.ReadLine();
    
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database
    string sql = $"INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('{nome}',{prezzo},{quantita});";
    SQLiteCommand command = new SQLiteCommand (sql, connection); //crea il comando sql da eseguire sulla connessione al db
    command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al db
    connection.Close();//chiude la connessione al db

}

static void VisualizzaProdotti()
{
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database
    string sql = "SELECT * FROM prodotti";
    SQLiteCommand command = new SQLiteCommand (sql, connection); //crea il comando sql da eseguire sulla connessione al db
    SQLiteDataReader reader = command.ExecuteReader();  //esegue il comando sql sulla connessione al db e 
                                                        //salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
    while (reader.Read())//Legge i dati dal reader finche ce ne sono
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantità: {reader["quantita"]}");
    }                            
    connection.Close(); //chiude la connessione al db
}

static void EliminaProdotto()
{
    Console.WriteLine("inserisci l'id del prodotto da eliminare");
    string id = Console.ReadLine();

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database
    string sql = $"DELETE FROM prodotti WHERE id = '{id}'";
    SQLiteCommand command = new SQLiteCommand (sql, connection); //crea il comando sql da eseguire sulla connessione al db
    command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al db
    connection.Close();//chiude la connessione al db
}

static void ModificaProdotto()
{
        Console.WriteLine("inserisci l'id del prodotto da modificare");
        string id = Console.ReadLine();

        SQLiteConnection connection = new SQLiteConnection ($"Data Source=database.db;Version=3;"); //crea la connessione al db
        connection.Open(); //apre la connessione al Database
        string sql = $"SELECT * FROM prodotti WHERE id = '{id}'";
         SQLiteCommand command = new SQLiteCommand (sql, connection); //crea il comando sql da eseguire sulla connessione al db
        SQLiteDataReader reader = command.ExecuteReader();  //esegue il comando sql sulla connessione al db e 
                                                            //salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
        if(reader.Read())//legge i dati dal reader finche ce ne sono
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantità: {reader["quantita"]}");
            Console.WriteLine("inserisci il nuovo nome del prodotto");
            string NuovoNome = Console.ReadLine();
            Console.WriteLine("inserisci il nuovo prezzo del prodotto");
            string NuovoPrezzo = Console.ReadLine();
            Console.WriteLine("inserisci la nuova quantità del prodotto");
            string NuovaQuantita = Console.ReadLine();

            sql = $"UPDATE prodotti SET nome = '{NuovoNome}', prezzo = {NuovoPrezzo}, quantita = {NuovaQuantita} WHERE id = '{id}'"; 
            command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al db
            command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al db
        }
    connection.Close();
}