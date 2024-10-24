// METODI DIZIONARIO
/*
i metodi per manipolare i dizionari sono:
- Add
- Clear
- ContainsKey
- ContainsValue
- Remove
- TryGetValue
*/

Console.Clear();

//Esempio di metodo Add
//aggiunge un elemento al dizionario
Dictionary<string, int> dizionario1 = new Dictionary<string, int>
{
    {"uno",1 },
    {"due",2 },
    {"tre",3 }

};

dizionario1.Add("quattro", 4); //aggiunge "quattro" con valore 4 a dizionario1

//Esempio di metodo Remove
//rimuove un elemento al dizionario

//rimuove l'elemento con chiave "due" da dizionario1
dizionario1.Remove("due");

//Esempio di metodo ContainsKey
//restituisce true se il dizionario contiene una chiave

//Restituisce true se dizionario1 contiene la chiave "uno"
Console.WriteLine(dizionario1.ContainsKey("uno"));

//Esempio di metodo ContainsValue
//restituisce true se il dizionario contiene un valore

//Restituisce true se dizionario1 contiene il valore 3
Console.WriteLine(dizionario1.ContainsValue(3));

//Esempio di metodo Clear
//cancella gli elementi di un dizionario

//cancella gli elementi da dizionario1
dizionario1.Clear();

//Esempio di dizionario con una coppia con una chiave e due valori
Dictionary<string, List<int>> dizionario2 = new Dictionary<string, List<int>>
{
    {"uno", new List<int> {1, 2, 3}},
    {"due", new List<int> {4, 5, 6}},
    {"tre", new List<int> {7, 8, 9}},
};

//aggiunge 10 alla lista di valori associata alla chiave "uno"
dizionario2.["uno"].Add(10);

//stampo il dizionario aggiornato
foreach(var coppia in dizionario2)
{
    Console.WriteLine($"{coppia.Key}\t{coppia.Value}");
}

//Esempio di dizionario con più chiavi associate ad un unico valore

//dichiara e inizializza un dizionario di liste e stringhe e interi
Dictionary<List<string>,int> dizionario3 = new Dictionary<List<string>, int>
{
    {new List<string> {"uno", "due", "tre"},1 },
    {new List<string> {"quattro", "cinque", "sei"},2 },
    {new List<string> {"sette", "otto", "nove"},3 }
};

//stampo il dizionario aggiornato
foreach(var coppia in dizionario3)
{
    Console.WriteLine($"{string.Join(", ",)}\t{coppia.Value}");
}

//Esempio di TryGetValue
// cerca un elemento in un dizionario e restituisce il valore associato

//dichiara e inizializza un dizionario di stringhe e interi
Dictionary<string, int> dizionario4 = new Dicotionary<string, int>
{
    {"uno",1 },
    {"due",2 },
    {"tre",3 }

};
int valore;
//cerca un elemento con chiave "due" in dizionario4 e restituisce il valore associato
if(dizionario4.TryGetValue("due",out valore))
{
    Console.WriteLine(valore);
}
else
{
    Console.WriteLine("chiave non trovata");
}