// Questo è un commento a riga singola

/*
Questo è un commento a riga multipla
*/

//Il metodo console.WriteLine stampa a video il testo passato come argomento
Console.WriteLine("Hello World!");

Console.WriteLine("Hello World!"); //Questo è un commento a fine riga

//metodo Console.ReadLine legge una riga di testo da tastiera

Console.WriteLine("Inserisci il tuo nome: ");

string nome = Console.ReadLine(); //Legge una riga da tastiera e la assegna alla variabile nome

// stampo il nome concatenato con una stringa

Console.WriteLine("Ciao " + nome + "!"); //(metodo principiante) con il segno + posso concatenare stringhe con variabili
//stampo il nome concatenato con una stringa utilizzando l'interpolazione
Console.WriteLine($"Ciao {nome}!"); //(metodo avanzato) con l'interpolazione posso concatenare stringhe con variabili
Console.WriteLine("Inserisci il tuo cognome:");
string cognome = Console.ReadLine();
Console.WriteLine($"Ciao {nome} {cognome}!"); // con l'interpolazione posso concatenare più variabili in modo semplificato
Console.WriteLine($"Ciao {nome.ToUpper()}!"); //il metodo ToUpper() trasforma una stringa in maiuscola
Console.WriteLine($"Ciao {nome.ToLower()}!"); //il metodo ToLower() trasforma una stringa in minuscola
//chiedo all'utente di inserire l'età
Console.WriteLine("Inserisci la tua eta':");
string eta = Console.ReadLine();
//Stampo l'età 
Console.WriteLine($"Hai {eta} anni");
//Stampo mome, cognome e età concatenati
Console.WriteLine($"Ciao {nome} {cognome} hai {eta} anni");
//dichiaro una variabile intera etaInt
int etaInt = 22; //inizializzo la variabile etaInt con il valore 22
string etaStr = etaInt.ToString();
//Concateno etaInt con la Stringa
Console.WriteLine($"Hai {etaInt} anni");

/*
i metodi di console permettono di gestire l'output o l'input ( il dialogo con l'utente) attaverso la console
WriteLine() stampa a video una stringa
ReadLine() legge a video da stringa

ho utilizzato due variabili di tipo string per memorizzare il nome e il cognome dell'utente
ho utilizzato una variabile di tipo int per memorizzare l'età dell'utente

il metodo ToUpper() trasforma una stringa in maiuscolo
il metodo ToLower() trasforma una stringa in minuscolo

ho provato ad utilizzare la variabile intera direttamente ma mi ha dato errore perchè doveva essere convertita in stringa
ho utilizzato il metodo ToString() per convertire un intero in una stringa e l'ho interpolata
*/