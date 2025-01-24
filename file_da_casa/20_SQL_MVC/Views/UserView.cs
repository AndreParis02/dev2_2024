class UserView
{
    private Database _db; //riferimento al modello di db
    public UserView(Database db) //costruttore della classe view che prende in input il modello di db
    {
        _db = db; //Inizializzazione del riferimento al modello
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi User");
        Console.WriteLine("2. Leggi users");
        Console.WriteLine("3. Esci");
    }

    //public void ShowUsers(List<string> users) //Metodo per visualizzare gli utenti
    public void ShowUsers(List<User> users)
    {
        foreach (var user in users)
        {
            //Console.WriteLine(user); //Visualizzazione dei nomi degli utenti
            Console.WriteLine($"{user.Id} - {user.Name}"); //Visualizzazione utenti
        }
    }

    public string GetUserName()
    {
        Console.WriteLine("Enter user name:");
        return Console.ReadLine();
    }

    public string GetInput()
    {
        return Console.ReadLine(); // Lettura dell'input dell'utente
    }
}