//File DatabaseInitializer.cs
//questo file gestisce la connesione al DB ed inizializza i dati tramite seeding

using System.Data.SQLite;
using System.Runtime.CompilerServices;

public static class DatabaseInitializer
{
    //il database verrà creato nella cartella dell'app
    private static string _connectionString = "Data Source=prodottiapp.db"; //utilizzeremo _connectionString in un metodo in modo da ottenere la connessione al db 
    public static void InitializerDatabase()
    {
        using var connection = new SQLiteConnection(_connectionString); // creiamo una connessione al db tramite using per garantire che venga chiusa correttamente

        connection.Open();  //apriamo la connessione 

        //gestisco l'eccezione se il db esiste gia in sql
        //creazione tabella Categorie

        var createCategorieTable = "CREATE TABLE IF NOT EXISTS Categorie (Id INTEGER PRIMARY KEY AUTOINCREMENT, Nome TEXT NOT NULL);";

        //Lancio il comando sulla connessione che ho creato
        using (var command = new SQLiteCommand(createCategorieTable, connection))
        {
            command.ExecuteNonQuery();
        }

        var createProdottiTable = @"CREATE TABLE IF NOT EXISTS Prodotti 
                                        (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                            Nome TEXT NOT NULL, 
                                            Prezzo REAL NOT NULL,
                                            CategoriaId INTEGER, FOREIGN KEY(CategoriaId) REFERENCES Categorie(Id)
                                        );
                                    ";

        //Lancio il comando sulla connessione che ho creato
        using (var command = new SQLiteCommand(createProdottiTable, connection))
        {
            command.ExecuteNonQuery();
        }

        //Seed dei dati per Categorie solo la prima volta
        //voglio sapere quanti record ci sono nella tabella Categorie in modo da poter decidere se fare il seed dei dati
        //seleziono il numero di categorie presenti nel db
        var countCommand = new SQLiteCommand("SELECT COUNT(*) FROM Categorie", connection);

        //Dato che count di sql è un valore numerico, posso usare execute scalar per ottenere il valore
        //execute scalar ritorna un oggetto quindi faccio il casting a long per ottenere il valore numerico
        var count = (long)countCommand.ExecuteScalar();

        //se il count è uguale a zero, allora non ci sono categorie nel db e posso fare il seed dei dati
        if (count == 0)
        {
            //sto inserendo più valori in una sola query quindi devo mettere le parentesi tonde intorno ai valori
            var insertCategorie = "INSERT INTO Categorie (Nome) VALUES('Casa'), ('Giochi'), ('Abbigliamento');";

            //Lancio il comando sulla connessione che ho creato
            using (var command = new SQLiteCommand(insertCategorie, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        var countCommand2 = new SQLiteCommand("SELECT COUNT(*) FROM Prodotti", connection);

        //Dato che count di sql è un valore numerico, posso usare execute scalar per ottenere il valore
        //execute scalar ritorna un oggetto quindi faccio il casting a long per ottenere il valore numerico
        var count2 = (long)countCommand.ExecuteScalar();

        //se il count è uguale a zero, allora non ci sono categorie nel db e posso fare il seed dei dati
        if (count == 0)
        {
            //per ottenere direttamente il nome dell'Id categoria che passiamo, nel campo Id categoria
            //ci mettiamo un altra query ovvero: (SELECT Id FROM Categorie WHERE Nome = 'Casa')
            var insertProdotti = @"INSERT INTO Prodotti 
            (Nome, Prezzo, CategoriaId) VALUES
            ('Prodotto1', 10.10, (SELECT Id FROM Categorie WHERE Nome = 'Casa')), 
            ('Prodotto2', 20.20, (SELECT Id FROM Categorie WHERE Nome = 'Giochi')), 
            ('Prodotto3', 30.30, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento'))
            ;";

            //Lancio il comando sulla connessione che ho creato
            using (var command = new SQLiteCommand(insertProdotti, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(_connectionString); //in questo modo la connessione è creata ma non aperta però può essere usata in altri metodi
    }

}



