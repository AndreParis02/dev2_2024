//GESTIONE FILES CSV

// ESEMPIO DI FILE CSV

//prodotto,quantità,prezzo
//Macchina,11,30
//Mouse,10,25

//LEGGERE UN CONTENUTO DA UN FILE CSV

string path =@"test.csv"; //in questo caso il file è nella stessa cartella del programma
string [] lines = File.ReadAllLines(path); // legge tutte le righe del file e le mette in un array di stringhe

foreach(string line in lines)
{
    Console.WriteLine(line); // stampa la riga
}

// creare una lista di stringhe partendo dal file csv

List<string> list =new List<string>();

foreach (string line in lines)
{
    list.Add(line);
}

//creare una file CSV con il nome del file che corrisponde al nome della prima colonna
//ed il contenuto del file che corrisponde al contenuto delle altre colonne disponibili

string[][] data = new string[lines.Length][];
for(int i = 1;i < lines.Length;i++)
{
    data[i] = lines[i].Split(','); //divide la riga in base alla virgola e mette i pezzi in un array di stringhe
}

for (int i = 1; i < data.Length; i++)
{
    string path2 = data[i][0] + ".csv"; // il nome del file è il nome del prodotto
    File.Create(path2).Close(); // crea il file e lo chiude subito
    
    for(int j = 1;j < data[i].Length;j++)
    {
        File.AppendAllText(path2, data[i][j] + "\n");
    }
}

//inserire i dati dentro il file tramite input utente

Console.WriteLine("inserisci i dati da mettere all'interno del file (separandoli con una ',') prodotto, quantità, prezzo");
string inserimento = Console.ReadLine();
File.AppendAllText(path,inserimento + "\n");

//eliminare un elemento specifico da un file csv (prodotto, quantità, prezzo)

Console.WriteLine("inserisci i dati da eliminare (separandoli con una ',') prodotto, quantità, prezzo");
string eliminare = Console.ReadLine();
string[] lines2 = File.ReadAllLines(path);
File.Create(path).Close(); //bisogna creare il file perchè altrimenti non si cancella il contenuto
foreach(string line in lines2)
{
    string[] data2 = line.Split(',');
    if(data2[0] != eliminare)
    {
        File.AppendAllText(path, line + "\n");
    }
}

//modificare un elemento specifico da un file csv (prodotto, quantità, prezzo)

Console.WriteLine("inserisci i dati da modificare (separandoli con una ',') prodotto, quantità, prezzo");
string modificare = Console.ReadLine();
string[] lines3 = File.ReadAllLines(path);
string[] temp = new string[lines3.Length];
File.Create(path).Close(); //bisogna creare il file perchè altrimenti non si cancella il contenuto

for(int i = 0;i < lines3.Length; i++)
{
    if(modificare != lines3[i])
    {
        temp[i] = lines3[i];
    }
    else
    {
        Console.WriteLine("inserisci i dati modificati (separandoli con una ',') prodotto, quantità, prezzo"); 
        string modifica = Console.ReadLine();  
        temp[i] = modifica;
    }
    File.AppendAllText(path,temp[i] + "\n");
}





  
