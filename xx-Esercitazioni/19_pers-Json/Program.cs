// GESTIONE FILES JSON

using Newtonsoft.Json; //libreria per gestire i file json

//LETTURA DI UN FILE JSON

/*
{
    "nome": "Andrea",
    "cognome": "Paris",
    "eta": 22
}
*/ 

string path = @"test.json"; // in questo caso il file è nella stessa cartella del programma
string json = File.ReadAllText(path); //legge il file

//ESEMPIO DI DESERIALIZZAZIONE DEL FILE JSON

dynamic obj = JsonConvert.DeserializeObject(json); // deserializza il file
Console.WriteLine($"\nnome:{obj.nome} \ncognome:{obj.cognome} \neta:{obj.eta}\n"); // stampa il file

//ESEMPIO DI DESERIALIZZAZIONE DEL FILE JSON CON PIU' LIVELLI

/*
{
    "nome": "Andrea",
    "cognome": "Paris",
    "eta": 22,
    "indirizzo":
    {
        "Via": "Via Ricca",
        "Città": "Genova"
    }
}
*/

string path2 = @"test2.json"; // in questo caso il file è nella stessa cartella del programma
string json2 = File.ReadAllText(path2); //legge il file

dynamic obj2 = JsonConvert.DeserializeObject(json2); // deserializza il file
Console.WriteLine($"\nnome:{obj2.nome} \ncognome:{obj2.cognome} \neta:{obj2.eta} \nVia:{obj2.indirizzo.via} \ncitta:{obj2.indirizzo.città}\n"); // stampa il file

//ESEMPIO DI DESERIALIZZAZIONE DEL FILE JSON COMPLESSO

/*
{
    "nome": "Andrea",
    "eta": 22,
    "impiegato": true,
    "indirizzo":
    {
        "via": "Via Ricca",
        "città": "Genova",
        "cCAP": "16139"
    },
    "numeriDiTelefono": [
        {"tipo": "casa", "numero": "1234-5678"},
        {"tipo": "telefono", "numero": "8765-4321"}
    ],
    "lingueParlate": ["italiano", "inglese", "spagnolo"],
    "sposato": false,
    "patente": null
}
*/

string path3 = @"test3.json"; // in questo caso il file è nella stessa cartella del programma
string json3 = File.ReadAllText(path3); //legge il file

dynamic obj3 = JsonConvert.DeserializeObject(json3); // deserializza il file
//stampa il file
Console.WriteLine($"\nnome:{obj3.nome} \neta:{obj3.eta} \nimpiegato: {obj3.impiegato} \nvia:{obj2.indirizzo.via} \ncittà:{obj2.indirizzo.città} \nCAP:{obj2.indirizzo.CAP}\n"); // stampa il file
//stampo i numeri di telefono (tramite codice)
Console.WriteLine($"\ntipo:{obj3.numeriditelefono[0].tipo} \nnumero:{obj3.numeriditelefono[0].numero}\n"); // stampa il file
//stampo le lingue parlate
Console.WriteLine($"\nlingua:{obj3.lingueparlate[0]}\n"); // stampa il file
//Stampo se è sposato
Console.WriteLine($"\nsposato:{obj3.sposato}\n"); // stampa il file
//stampo se ha la patente
Console.WriteLine($"\npatente:{obj3.patente}\n"); // stampa il file






