// GESTIONE FILES JSON

using System.Globalization;
using System.Runtime.InteropServices.Marshalling;
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

//ESEMPIO DI SERIALIZZAZIONE DEL FILE JSON

//chideo all'utente di inserire i dati
Console.Write("inserisci il nome: ");
string nome = Console.ReadLine();
Console.Write("inserisci il cognome: ");
string cognome = Console.ReadLine();
Console.Write("inserisci l'indirizzo: ");
string indirizzo = Console.ReadLine();
Console.Write("inserisci la citta: ");
string citta = Console.ReadLine();
//creo un oggetto con i dati inseriti

var obj4 = new
{
    nome = nome,
    cognome = cognome,
    indirizzo = indirizzo,
    citta = citta
};

//serializzo l'oggetto

string json4  = JsonConvert.SerializeObject(obj4, Formatting.Indented);


//uso di formatting indented: posso formattare il file in modo che sia più leggibile a capo dopo ogni virgola e parentesi graffa

File.WriteAllText("test4.json", json4);

//SCRITTURA DI UN FILE JSON

//ESEMPIO SCRITTURA DIRETTA DI UN OGGETTO COMPLESSO

var obj5 = new
{
    nome = "Andrea",
    eta = 22,
    impiegato = true,
    indirizzo = new
    {
        via = "Via Ricca",
        citta = "Genova",
        CAP = "16129"
    },
    numeriDiTelefono = new []
    {
       new {tipo = "casa", numero = "1234-5678"},
        new { tipo = "telefono", numero = "8765-4321"}
    },
    lingueParlate = new[] {"italiano", "inglese", "spagnolo"},
    sposato = false,
    patente = (string) null
};

string json5  = JsonConvert.SerializeObject(obj5, Formatting.Indented); //serializza l'oggetto

File.WriteAllText("test5.json", json5); //scrive il file

//ESEMPIO DI SCRITTURA DI PIU OGGETTI IN UN FILE JSON

//crea un array d oggetti
var obj6 = new[]
{
    new {nome = "Mario", cognome = "Rossi"},
    new {nome = "Luca", cognome = "Bianchi" }
};
//serializzo l'array
string json6 = JsonConvert.SerializeObject(obj6, Formatting.Indented); //serializza l'oggetto
//scrio il file
File.WriteAllText("test6.json", json6);

//AGGIUNTA DI UN OGGETTO  IN UN FILE JSON

//leggo il file
string json7 = File.ReadAllText("test6.json");
//deserializzo il file
dynamic obj7 = JsonConvert.DeserializeObject(json7);
//aggiungo un oggetto all'array
var obj7new = new {nome = "Paolo", cognome = "Verdi"};
//aggiungo l'oggetto all'array
List<dynamic> list = obj7.ToObject<List<dynamic>>();
list.Add(obj7new);
//serializzo l'array
string json7new = JsonConvert.SerializeObject(list, Formatting.Indented);
//scrivo il file
File.WriteAllText("test6.json", json7new); //json7new è il file di output con l'oggetto aggiunto


//ESEMPIO DI CANCELLAZIONE DI UN OGGETTO IN UN FILE JSON

//leggo il file
string json8 = File.ReadAllText("test6.json");
//deserializzo il file
dynamic obj8 = JsonConvert.DeserializeObject(json8);
//rimuovo l'oggetto dall'array
List<dynamic> list8 = obj8.ToObject<List<dynamic>>();
list8.RemoveAt(0);
//serializzo l'array
string json8new = JsonConvert.SerializeObject(list8, Formatting.Indented);
//scrivo il file
File.WriteAllText("test6.json", json8new);

//ESEMPIO DI MODIFICA DI UN OGGETTO IN UN FILE

//leggo il file
string json9 = File.ReadAllText("test6.json");
//deserializzo il file
dynamic obj9 = JsonConvert.DeserializeObject(json9);
//modifico l'oggetto dall'array
List<dynamic> list9 = obj9.ToObject<List<dynamic>>();
list9[0].nome = "Giovanni";
//serializzo l'array
string json9new = JsonConvert.SerializeObject(list9, Formatting.Indented);
//scrivo il file
File.WriteAllText("test6.json", json9new);

//ESEMPIO DI LETTURA DI UN FILE JSON CON UN ARRAY DI OGGETTI

/*
[
    {
        "nome": "Mario",
        "cognome": "Rossi"
    }
    {
        "nome": "Luca",
        "cognome": "Bianchi"
    }
]
*/

string path10 = @"test6.json"; //n questo caso il file è nella stessa cartella del programma
string json10 = File.ReadAllText(path10); //legge il file

dynamic obj10 = JsonConvert.DeserializeObject(json10); //deserializza il file

//stampo il file
foreach (var item in obj10)
{
    Console.WriteLine($"nome :{item.nome} cognome: {item.cognome}");
}

//ESEMPIO DI CREAZIONE DI UN FILE JSON DA UN DIZIONARIO

Dictionary<string, string> dizionario = new Dictionary<string, string>
{
    {"nome", "Mario"},
    {"cognome", "Rossi"},
};

string json11 = JsonConvert.SerializeObject(dizionario, Formatting.Indented); // serializzo il dizionario

File.WriteAllText("test11.json", json11); // scrivo il file

// ESEMPIO D ILETTURA DI UN FILE 