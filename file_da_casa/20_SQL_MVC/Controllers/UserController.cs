using System.Diagnostics;

class UserController
{
    private Database _db; //Riferimento al modello di db
    private UserView _view; //Riferimento alla view

    public UserController(Database db, UserView view) //costruttore della classe controller che prende in input il modello di db e la view
    {
        _db = db; //Inizializzazione del riferimento al modello
        _view = view; //Inizializzazione del riferimento alla vista
    }
    public void MainMenu()
    {

        while (true)
        {
            _view.ShowMainMenu(); //Visualizzazione del menu principale con metodo servito da view
            var input = _view.GetInput(); //Lettura dell'input dell'utente con metodo servito da view
            if (input == "1")
            {
                AddUser(); //Aggiunta di un utente
            }
            else if (input == "2")
            {
                ShowUsers(); //Visualizzazione degli utenti
            }
            else if (input == "3")
            {
                _db.CloseConnection(); //Chiusura della connessione al db
                break; //Uscita dal programma
            }
        }
    }

    private void AddUser()
    {
        var name = _view.GetUserName();
        _db.AddUser(name); //Aggiunta dell'utente al db con metodo servito da db
    }
    private void ShowUsers()
    {
        var users = _db.GetUsers(); //Lettura degli utenti dal db
        _view.ShowUsers(users); //Visualizzazione degli utenti
    }

}