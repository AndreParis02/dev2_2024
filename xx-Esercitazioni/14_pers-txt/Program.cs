// GESTIONE FILES TXT

// LEGGERE UN CONTENUTO DA UN FILE TXT

string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
string[] lines = File.ReadAllLines(path); //Legge tutte le righe del file e le mette in un array di stringhe

foreach(string line in lines)
{
    Console.WriteLine(line); //stampa la riga 
}

/*
string[] nomi = new string[lines.Length]; // crea un array di stringhe con la lunghezza del numero di righe del file
for(int i = 0;i < lines.Length;i++)
{
    nomi[i] = lines[i]; //assegna ad ogni elemento dell'array di stringhe il valore della righa corrispondente
}
foreach(string nome in nomi)
{
    Console.WriteLine(nome); //stampa la riga 
}
*/

//LEGGERE UN CONTENUTO E STAMPARE SOLO LE RIGHE CHE INIZIANO CON UNA DETERMINATA LETTERA

//string path = @"test.txt"; 
//string[] lines = File.ReadAllLines(path); 

foreach(string line in lines)
{
    if(line.StartsWith("A")) //controlla se la riga inizia con la lettera
    {
         Console.WriteLine(line); //stampa la riga 
    }
}

//LEGGERE UN CONTENUTO E STAMPARE SOLO LE RIGHE CHE INIZIANO CON UNA DETERMINATA LETTERA
// SE NESSUN NOME INIZIA CON LA LETTERA SCELTA, DA UN MESSAGGIO DI ERRORE

int nPresente = 0;

foreach(string line in lines)
{
    if(line.StartsWith("R")) //controlla se la riga inizia con la lettera
    {
         Console.WriteLine(line); //stampa la riga 
         nPresente++;
    }
}
if(nPresente == 0)
{
    Console.WriteLine("Non è stato trovato nessun nome con la lettera inserita");
}

//LEGGERE UN CONTENUTO E STAMPARE SOLO LE RIGHE CHE INIZIANO CON UNA DETERMINATA LETTERA
// SE NESSUN NOME INIZIA CON LA LETTERA SCELTA, DA UN MESSAGGIO DI ERRORE
//CREARE UN TXT CON LE RIGHE CHE INIZIANO CON LA LETTERA SCELTA

string path2 = @"testOutput.txt"; // in questo caso il file è nella stessa cartella del programma
File.Create(path2).Close(); // crea il file e lo chiude subito
bool nessunNomeInizialeConLettera = false; 

foreach(string line in lines)
{
    if(line.StartsWith("A"))
    {
        nessunNomeInizialeConLettera = false;
        File.AppendAllText(path2, line + "\n");// scrive la riga del file di output andando a capo
    }
}
if(nessunNomeInizialeConLettera) //se il booleano è vero allora stampa "nessun nome inizia con la lettera a
{
    Console.WriteLine("nessun nome inizia con la lettera scelta");
} 

//AGGIUNGERE UNA RIGA DI TESTO IN UNA POSIZIONE SPECIFICA

//stampo la lunghezza dell'array
Console.WriteLine(lines.Length);
lines[lines.Length - 2] += " indirizzo"; //aggiunge "INDIRIZZO" alla penultima riga
File.WriteAllLines(path2, lines); //scrive tutte le righe del file


//AGGIUNGERE UNA RIGA IN UNA POSIZIONE SPECIFICA USANDO L'ACCENTO CIRCONFLESSO
lines[^ 4] += " numero di telefono 2"; // aggiunge il testo partendo dall'utlima posizione
File.WriteAllLines(path2, lines); //scrive tutte le righe del file


//SOVRASCRIVERE UNA RIGA DI TESTO IN UNA POSIZIONE SPECIFICA
lines[lines.Length - 2] = "Numero di telefono"; //aggiunge "INDIRIZZO" alla penultima riga
File.WriteAllLines(path2, lines); //scrive tutte le righe del file
