var db = new Database(); //Modello di db in modo che sia possibile utilizzare i metodi per la gestione del db
var view = new View(db); //Modello di vista è db tra parentesi perchè la vista deve avere accesso al db
var controller = new Controller(db, view); //Modello di controller che deve avere accesso al db e alla lista
controller.MainMenu(); // Metodo per gestire il menu principale






