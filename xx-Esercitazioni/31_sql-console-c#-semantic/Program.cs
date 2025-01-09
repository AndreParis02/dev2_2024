using System.ComponentModel;
using System.Data.SQLite;

//comando installazione pacchetto System.Data.SQLite
//dotnet add package System.Data.SQLite

string path = @"database.db"; //la rotta del file del database

if (!File.Exists(path)) //se il file del db non esiste
{
    SQLiteConnection.CreateFile(path); //crea il file del db
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;");
    connection.Open(); //apre la connessione al Database

    string sql = @"
                    CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                    CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER, FOREIGN KEY (id_categoria) REFERENCES categorie(id));
                    INSERT INTO categorie (nome) VALUES ('categoria1'), ('categoria2'), ('categoria3');
                    INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('prodotto1', 1, 10, 1), ('prodotto2', 2, 20, 2), ('prodotto3', 3, 30, 3);  
                ";

    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db                                 
    command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al db nonquery significa che non si aspetta risultato
    connection.Close(); // chiude la connessione al db;
}
while (true)
{
    Console.WriteLine("1 - Gestione prodotti");
    Console.WriteLine("2 - Gestione categorie");
    Console.WriteLine("3 - Gestione visualizzazione");
    Console.WriteLine("0 - esci");
    Console.WriteLine("scegli un opzione: ");
    string scelta = Console.ReadLine();
    if (scelta == "1")
    {
        Console.Clear(); //pulisco la console
        GestioneProdotto();
    }
    else if (scelta == "2")
    {
        Console.Clear(); //pulisco la console
        GestioneCategorie();
    }
    else if (scelta == "3")
    {
        Console.Clear();
         GestioneVisualizzazione();
    }
    else if (scelta == "0")
    {
        break;
    }
}

// OPERAZIONI CRUD PRODOTTI
static void GestioneProdotto()
{
    while (true)
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
}

static void InserisciProdotto()
{
    Console.WriteLine("inserisci il nome del prodotto");
    string nome = Console.ReadLine();
    Console.WriteLine("inserisci il prezzo del prodotto");
    string prezzo = Console.ReadLine();
    Console.WriteLine("inserisci la quantità del prodotto");
    string quantita = Console.ReadLine();
    Console.WriteLine("inserisci l'id della categoria corrispondente al prodotto");
    string id_categoria = Console.ReadLine();

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database
    string sql = $"INSERT INTO prodotti (nome, prezzo, quantita,id_categoria) VALUES ('{nome}',{prezzo},{quantita},{id_categoria});";
    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db
    command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al db
    connection.Close();//chiude la connessione al db
}

static void VisualizzaProdotti()
{
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database
    string sql = @"SELECT prodotti.id, prodotti.nome, prodotti.prezzo, prodotti.quantita, categorie.nome AS nome_categoria FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id";
    //AS nome_categoria serve per rinominare la colonna in modo da poterla visualizzare con un nome diverso
    //JOIN serve per unire due tabelle in base a una condizione
    //la condizione è che il campo id_categoria della tabella prodotti sia uguale al campo id della tabella categorie

    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db
    SQLiteDataReader reader = command.ExecuteReader();  //esegue il comando sql sulla connessione al db e salva i dati in reader

    while (reader.Read())//Legge i dati dal reader finche ce ne sono
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantità: {reader["quantita"]}, categoria: {reader["nome_categoria"]}");
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
    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db
    command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al db
    connection.Close();//chiude la connessione al db
}

static void ModificaProdotto()
{
    Console.WriteLine("inserisci l'id del prodotto da modificare");
    string id = Console.ReadLine();

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database
    string sql = $"SELECT * FROM prodotti WHERE id = '{id}'";
    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db
    SQLiteDataReader reader = command.ExecuteReader();  //esegue il comando sql sulla connessione al db e 
                                                        //salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
    if (reader.Read())//legge i dati dal reader finche ce ne sono
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantità: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
        Console.WriteLine("inserisci il nuovo nome del prodotto");
        string NuovoNome = Console.ReadLine();
        Console.WriteLine("inserisci il nuovo prezzo del prodotto");
        string NuovoPrezzo = Console.ReadLine();
        Console.WriteLine("inserisci la nuova quantità del prodotto");
        string NuovaQuantita = Console.ReadLine();
        Console.WriteLine("inserisci il nuovo id categoria corrispondente al prodotto");
        string NuovoIdCategoria = Console.ReadLine();

        sql = $"UPDATE prodotti SET nome = '{NuovoNome}', prezzo = {NuovoPrezzo}, quantita = {NuovaQuantita}, id_categoria = {NuovoIdCategoria} WHERE id = '{id}'";
        command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al db
        command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al db
        reader.Close();
    }
    connection.Close();
}

// OPERAZIONI CRUD CATEGORIE
static void GestioneCategorie()
{
    Console.WriteLine("1 - inserisci categoria");
    Console.WriteLine("2 - visualizza categorie");
    Console.WriteLine("3 - elimina categoria");
    Console.WriteLine("4 - modifica categoria");
    Console.WriteLine("0 - esci");
    Console.WriteLine("scegli un opzione: ");
    string scelta = Console.ReadLine();
    while (true)
    {
        if (scelta == "1")
        {
            Console.Clear(); //pulisco la console
            InserisciCategoria();
        }
        else if (scelta == "2")
        {
            Console.Clear(); //pulisco la console
            VisualizzaCategorie();
        }
        else if (scelta == "3")
        {
            Console.Clear(); //pulisco la console
            VisualizzaCategorie();
            Console.WriteLine("");
            EliminaCategoria();
        }
        else if (scelta == "4")
        {
            Console.Clear(); //pulisco la console
            VisualizzaCategorie();
            Console.WriteLine("");
            ModificaCategoria();
        }
        else if (scelta == "0")
        {
            break;
        }
    }
}

static void InserisciCategoria()
{
    Console.WriteLine("inserisci il nome della categoria");
    string nome = Console.ReadLine();

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database
    string sql = $"INSERT INTO categorie (nome) VALUES ('{nome}');";
    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db
    command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al db
    connection.Close();//chiude la connessione al db
}

static void VisualizzaCategorie()
{
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database
    string sql = @"SELECT * FROM categorie";

    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db
    SQLiteDataReader reader = command.ExecuteReader();  //esegue il comando sql sulla connessione al db e salva i dati in reader

    while (reader.Read())//Legge i dati dal reader finche ce ne sono
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}");
    }
    connection.Close(); //chiude la connessione al db
}

static void EliminaCategoria()
{
    Console.WriteLine("inserisci l'id della categoria da eliminare");
    string id = Console.ReadLine();

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database
    string sql = $"DELETE FROM categorie WHERE id = '{id}'";
    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db
    command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al db
    connection.Close();//chiude la connessione al db
}

static void ModificaCategoria()
{
    Console.WriteLine("inserisci l'id della categoria da modificare");
    string id = Console.ReadLine();

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database
    string sql = $"SELECT * FROM categorie WHERE id = '{id}'";
    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db
    SQLiteDataReader reader = command.ExecuteReader();  //esegue il comando sql sulla connessione al db e 
                                                        //salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
    if (reader.Read())//legge i dati dal reader finche ce ne sono
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}");
        Console.WriteLine("inserisci il nuovo nome della categoria");
        string NuovoNome = Console.ReadLine();

        sql = $"UPDATE categorie SET nome = '{NuovoNome}' WHERE id = '{id}'";
        command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al db
        command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al db
        reader.Close();
    }
    connection.Close();
}

//VISUALIZZAZIONE PRODOTTI
static void GestioneVisualizzazione()
{
    Console.WriteLine("1 - visualizza per prezzo dal più basso");
    Console.WriteLine("2 - visualizza per prezzo dal più alto");
    Console.WriteLine("3 - visualizza per range di prezzo");
    Console.WriteLine("4 - visualizza per categoria");
    Console.WriteLine("0 - esci");
    string scelta = Console.ReadLine();
    while (true)
    {
        if (scelta == "1")
        {
            Console.Clear();
            VisualizzaPrezzoCrescente();
            break;
        }
        else if (scelta == "2")
        {
            Console.Clear();
            VisualizzaPrezzoDecrescente();
            break;
        }
        else if (scelta == "3")
        {
            Console.Clear();
            VisualizzaPerRangePrezzo();
            break;
        }
        else if (scelta == "4")
        {
            Console.Clear();
            VisualizzaPerCategoria();
            break;
        }
        else if (scelta == "0")
        {
            break;
        }
    }
}

static void VisualizzaPrezzoCrescente()
{
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database
    string sql = @"SELECT prodotti.id, prodotti.nome, prodotti.prezzo, prodotti.quantita, categorie.nome AS nome_categoria FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id ORDER BY prodotti.prezzo ASC";
    //AS nome_categoria serve per rinominare la colonna in modo da poterla visualizzare con un nome diverso
    //JOIN serve per unire due tabelle in base a una condizione
    //la condizione è che il campo id_categoria della tabella prodotti sia uguale al campo id della tabella categorie

    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db
    SQLiteDataReader reader = command.ExecuteReader();  //esegue il comando sql sulla connessione al db e salva i dati in reader

    while (reader.Read())//Legge i dati dal reader finche ce ne sono
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantità: {reader["quantita"]}, categoria: {reader["nome_categoria"]}");
    }
    connection.Close(); //chiude la connessione al db
}

static void VisualizzaPrezzoDecrescente()
{
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database
    string sql = @"SELECT prodotti.id, prodotti.nome, prodotti.prezzo, prodotti.quantita, categorie.nome AS nome_categoria FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id ORDER BY prodotti.prezzo DESC";
    //AS nome_categoria serve per rinominare la colonna in modo da poterla visualizzare con un nome diverso
    //JOIN serve per unire due tabelle in base a una condizione
    //la condizione è che il campo id_categoria della tabella prodotti sia uguale al campo id della tabella categorie

    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db
    SQLiteDataReader reader = command.ExecuteReader();  //esegue il comando sql sulla connessione al db e salva i dati in reader

    while (reader.Read())//Legge i dati dal reader finche ce ne sono
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantità: {reader["quantita"]}, categoria: {reader["nome_categoria"]}");
    }
    connection.Close(); //chiude la connessione al db
}

static void VisualizzaPerRangePrezzo()
{
    Console.WriteLine("inserisci il valore di prezzo minimo");
    decimal min = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("inserisci il valore di prezzo massimo");
    decimal max = Convert.ToDecimal(Console.ReadLine());

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database
    string sql = $"SELECT prodotti.id, prodotti.nome, prodotti.prezzo, prodotti.quantita, categorie.nome AS nome_categoria FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id WHERE prodotti.prezzo BETWEEN {min} AND {max}";
    //AS nome_categoria serve per rinominare la colonna in modo da poterla visualizzare con un nome diverso
    //JOIN serve per unire due tabelle in base a una condizione
    //la condizione è che il campo id_categoria della tabella prodotti sia uguale al campo id della tabella categorie

    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db
    SQLiteDataReader reader = command.ExecuteReader();  //esegue il comando sql sulla connessione al db e salva i dati in reader

    while (reader.Read())//Legge i dati dal reader finche ce ne sono
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantità: {reader["quantita"]}, categoria: {reader["nome_categoria"]}");
    }
    connection.Close(); //chiude la connessione al db
}

static void VisualizzaPerCategoria()
{
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessione al db
    connection.Open(); //apre la connessione al Database

    Console.WriteLine("inserisci il nome della Categoria da filtrare");
    string filtro = Console.ReadLine();
    
    string sql = $"SELECT prodotti.id, prodotti.nome, prodotti.prezzo, prodotti.quantita, categorie.nome AS nome_categoria FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id WHERE categorie.nome = '{filtro}' ORDER BY prodotti.nome DESC";
    //AS nome_categoria serve per rinominare la colonna in modo da poterla visualizzare con un nome diverso
    //JOIN serve per unire due tabelle in base a una condizione
    //la condizione è che il campo id_categoria della tabella prodotti sia uguale al campo id della tabella categorie

    SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al db
    SQLiteDataReader reader = command.ExecuteReader();  //esegue il comando sql sulla connessione al db e salva i dati in reader

    while (reader.Read())//Legge i dati dal reader finche ce ne sono
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantità: {reader["quantita"]}, categoria: {reader["nome_categoria"]}");
    }
    connection.Close(); //chiude la connessione al db
}