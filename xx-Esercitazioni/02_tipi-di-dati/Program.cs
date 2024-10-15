//I TIPI DI DATI SEMPLICI 

//variabili di tipo intero
int eta = 22; //dichiarazione e inizializzazione di una variabile di tipo intero

int eta2; //dichiarazione di una variabile di tipo intero
eta2 = 32; //inizializzaizone di una variabile di tipo intero

//variabile di tipo decimale
double altezza = 1.78; //dichiarazione e inizializzazione di una variabile di tipo decimale

//variabile di tipo carattere 
char iniziale = 'A'; //dichiarazione e inizializzazione di una variabile di tipo carattere

//variabile di tipo stringa
string nome = "Andrea"; //dichiarazione e inizializzazione di una variabile di tipo stringa

//variabili di tipo booleano
bool maggiorenne = true; //dichiarazione e inizializzazione di una variabile di tipo booleano

//variabili di tipo data
DateTime dataNascita= new DateTime(2002, 12, 24); //dichiarazione e inizializzazione di una variabile di tipo data

//esempio di utilizzo di una variabile attraverso i metodi di console
//utilizzando l'interpolazione di stringhe
Console.WriteLine($"La variabile eta' contiene il valore {eta}"); //output: la variabile eta' contiente il valore eta
Console.WriteLine($"La variabile altezza contiene il valore {altezza}"); //output: la variabile altezza contiente il valore altezza

//ricevo l'input dall'utente e lo salvo in una variabile
Console.WriteLine("Scrivi il tuo nome utente: ");
string NomeUtente = Console.ReadLine();
Console.WriteLine($"Ciao {NomeUtente}!"); //Output: ciao Andrea!

//I TIPI DI DATI COMPLESSI (o strutture di dati)
// un insieme di dati dello stesso tipo

//array
int[] numeri = new int[5]; //dichiarazione e inizializzazione di un array du interi di 5 elementi
                           //new è una parola chiave che serve per creare un nuovo oggetto (costruttore)
//inserimento di valori nell'array
numeri[0] = 10;
numeri[1] = 20;
numeri[2] = 30;
numeri[3] = 40;
numeri[4] = 50;

//inserimento di valori multipli nell'array
int[] numeri2 = new int[] {10, 20, 30, 40, 50}; //dichiarazione e inizializzazione di una array di interi di 5 elementi

// la caratteristica principale degli array e che sono di dimensione fissa

//lista
List<int> numeri3 = new List<int>(); // dichiarazione di una lista di interi
                                     //le liste sono di dimensione variabile

//inserimento di valori nella lista
numeri3.Add(10); // inserisco il valore 10 nella lista usando il metodo add
numeri3.Add(20);
numeri3.Add(30);
numeri3.Add(40);
numeri3.Add(50);

//insermiento valori multipli nella lista
List<int> numeri4 =new List<int> {10,20, 30, 40, 50}; //dichiarazione e inizializzazione di una lista di interi

//sia le liste che gli array sono collezione di dati che possono essere di int, double, char, string, ecc...
//esempio di lista di stringhe
List<string> nomi = new List<string> {"Mario", "Luigi", "Peach"};

//Dizionario
Dictionary<string, int> voti = new Dictionary<String, int>(); //dichiarazione di un dizionario con chiave di tipo string
//in questo caso string è la chiave e int il valore

//BEST PRACTICES PER LA DICHIARAZIONE DI VARIABILI
//dichiarare le variabili con nomi significativi
//dichiarare le variabili con la notazione CamelCase o PascalCase
//esempio di camel case etaStudente
//esempio di pascal case EtaStudente