
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

bool temp = true;
while(temp)
{
    Console.WriteLine("Sei:\n 1. un cliente; \n 2. Un dipendente; \n 0. Esci\n");    
    string dip = Console.ReadLine();

    switch(dip)
    {
        case "1":
            manipolazioneCarrello();
        break;
        case "2":
            manipolazioneCatalogo();
        break;
        case "0":
                temp = false;
                break;
            default:
                Console.WriteLine("Scelta non valida. Riprova.");
                break;
    }

}

Console.WriteLine("Grazie per aver visitato il Supermercato!");

//------------------------------------------Funzione manipolazione Carrello------------------------------------------

static void manipolazioneCarrello()
{
    // Variabile per controllare il ciclo
    bool continua = true;

    // Menu principale
    while (continua)
    {
        Console.WriteLine("\nScegli un'opzione di gestione carrello:");
        Console.WriteLine("1. Visualizza i prodotti");
        Console.WriteLine("2. Modifica la quantità di un prodotto");
        Console.WriteLine("3. Aggiungi un prodotto al carrello");
        Console.WriteLine("4. Rimuovi un prodotto dal carrello");
        Console.WriteLine("0. Esci");

        Console.Write("\nInserisci la tua scelta: ");
        string scelta = Console.ReadLine();

        switch (scelta)
        {
             case "1":
                VisualizzaProdottiCarrello();
                break;
/*
            case "2":
                ModificaQtaProdotto();
                break;
  */          
            case "3":
                AggiungiAlCarrello();
                break;
   /*         
            case "4":
                RimuoviDalCarrello();
                break;
*/
            case "0":
                continua = false;
                break;

            default:
                Console.WriteLine("Scelta non valida. Riprova.");
                break;
        }
    }
}

//------------------------------------------Funzione manipolazione Catalogo------------------------------------------
static void manipolazioneCatalogo()
{
    // Variabile per controllare il ciclo
    bool continua = true;

    // Menu principale
    while (continua)
    {
        Console.WriteLine("\nScegli un'opzione di gestione catalogo:");
        Console.WriteLine("1. Visualizza i prodotti");
        Console.WriteLine("2. Modifica un prodotto");
        Console.WriteLine("3. Aggiungi un prodotto al catalogo");
        Console.WriteLine("4. Rimuovi un prodotto dal catalogo");
        Console.WriteLine("0. Esci");

        Console.Write("\nInserisci la tua scelta: ");
        string scelta = Console.ReadLine();

        switch (scelta)
        {
            case "1":
                VisualizzaProdottiCatalogo();
                break;

            case "2":
                ModificaProdottoCatalogo();
                break;
            
            case "3":
                AggiungiAlCatalogo();
                break;
            
            case "4":
                RimuoviDalCatalogo();
                break;

            case "0":
                continua = false;
                break;

            default:
                Console.WriteLine("Scelta non valida. Riprova.");
                break;
        }
    }
}

//------------------------------------------Funzione visualizza Catalogo------------------------------------------

static void VisualizzaProdottiCatalogo()
{
    string path = @"Catalogo.json"; // in questo caso il file è nella stessa cartella del programma
    string catalogo = File.ReadAllText(path); //legge il file

    dynamic obj = JsonConvert.DeserializeObject(catalogo)!; // deserializza il file

    //stampo il file
    foreach (var item in obj)
    {
        Console.WriteLine($"\nID:{item.ID} \nNome Prodotto:{item.nome} \nPrezzo:{item.prezzo} \nQuantità:{item.quantita}\n"); // stampa il file
    }
}

//------------------------------------------Funzione modifica prodotto------------------------------------------

static void ModificaProdottoCatalogo()
{
    Console.WriteLine("inserisci il nome del prodotto da modificare: ");
    string temp = Console.ReadLine()!;
    //leggo il file
    string catalogo = File.ReadAllText("catalogo.json");
    //deserializzo il file
    dynamic obj = JsonConvert.DeserializeObject(catalogo)!;
    //modifico l'oggetto dall'array
    List<dynamic> list = obj.ToObject<List<dynamic>>();
    for(int i = 0;i < list.Count; i++)
    {
        if(list[i].nome == temp)
        {
            Console.Write("\nInserisci il campo che vuoi modificare \n 1- ID \n 2- nome \n 3- prezzo \n 4- quantità \n 5- tutto \n 0- esci\n");
            string mod = Console.ReadLine()!;
            
            string ID_Modificato;
            string prezzo_Modificato;
            string nome_Modificato;
            int qta_Modificato;
            bool continua = true;

                switch (mod)
                {
                case "1":
                        Console.WriteLine("inserisci l'ID del prodotto modificato");
                        ID_Modificato = Console.ReadLine()!;
                        list[i].ID = ID_Modificato;
                        Console.WriteLine("ID del prodotto modificato con successo!");
                    break;
                    case "2":
                        Console.WriteLine("inserisci il nome del prodotto modificato");
                        nome_Modificato = Console.ReadLine()!;
                        list[i].nome = nome_Modificato;
                        Console.WriteLine("Nome del prodotto modificato con successo!");
                    break;
                    case "3":
                        Console.WriteLine("inserisci il prezzo del prodotto modificato (usa il punto anziche la virgola)");
                        prezzo_Modificato = Console.ReadLine()!;
                        list[i].prezzo = prezzo_Modificato;
                        Console.WriteLine("Prezzo del prodotto modificato con successo!");
                    break;
                    case "4":
                        Console.WriteLine("inserisci la quantità del prodotto modificato ");
                        qta_Modificato = Int32.Parse(Console.ReadLine()!);
                        list[i].quantita = qta_Modificato;
                        Console.WriteLine("Quantità del prodotto modificata con successo!");
                    break;
                    case "5":
                        Console.WriteLine("inserisci l'ID del prodotto modificato");
                        ID_Modificato = Console.ReadLine()!;
                        list[i].ID = ID_Modificato;

                          Console.WriteLine("inserisci l'ID del prodotto modificato");
                        ID_Modificato = Console.ReadLine()!;
                        list[i].ID = ID_Modificato;

                        Console.WriteLine("inserisci il prezzo del prodotto modificato (usa il punto anziche la virgola)");
                        prezzo_Modificato = Console.ReadLine()!;
                        list[i].prezzo = prezzo_Modificato;

                        Console.WriteLine("inserisci la quantità del prodotto modificato");
                        qta_Modificato = Int32.Parse(Console.ReadLine()!);
                        list[i].quantita = qta_Modificato;

                        Console.WriteLine("prodotto modificato con successo!");
                    break;
                    case "0":
                    continua = false;
                    break;
                    default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
                }   
               
        }
    }
    //serializzo l'array
    string jsonModificato = JsonConvert.SerializeObject(list, Formatting.Indented);
    //scrivo il file
    File.WriteAllText("catalogo.json", jsonModificato);
}

//------------------------------------------Funzione aggiungi prodotto al catalogo------------------------------------------

static void AggiungiAlCatalogo()
{
    //leggo il file
    string catalogo = File.ReadAllText("catalogo.json");
    //deserializzo il file
    dynamic obj = JsonConvert.DeserializeObject(catalogo)!;
    //modifico l'oggetto dall'array
    List<dynamic> list = obj.ToObject<List<dynamic>>();

    string ID_Add;
    string nome_Add;
    string prezzo_Add;
    int qta_Add;
    bool Presente = false;
        
    Console.Write("\nInserisci il nome del prodotto da aggiungere al catalogo: ");
    nome_Add = Console.ReadLine()!;
    
    for(int i = 0;i < list.Count; i++)
    {
        if(list[i].nome == nome_Add)
        {
            Presente = true;
        }
    }

    if(Presente == false)
    {
        Console.WriteLine("inserisci l'ID del prodotto da aggiungere");
        ID_Add = Console.ReadLine()!;

        Console.WriteLine("inserisci il prezzo del prodotto da aggiungere (usa il punto anziche la virgola)");
        prezzo_Add = Console.ReadLine()!;

        Console.WriteLine("inserisci la quantità del prodotto da aggiungere");
        qta_Add = Int32.Parse(Console.ReadLine()!);


        var objnew = new {ID = ID_Add, nome= nome_Add, prezzo = prezzo_Add, quantita = qta_Add};
        //aggiungo l'oggetto all'array
        list.Add(objnew);
        //serializzo l'array
        string jsonAdd = JsonConvert.SerializeObject(list, Formatting.Indented);
        //scrivo il file
        File.WriteAllText("catalogo.json", jsonAdd);      
    }
    else
    {
        Console.WriteLine($"Il prodotto {nome_Add} è gia presente nel catalogo!");
    }
}

//------------------------------------------Funzione rimuovi prodotto dal catalogo------------------------------------------

static void RimuoviDalCatalogo()
{
    //leggo il file
    string catalogo = File.ReadAllText("catalogo.json");
    //deserializzo il file
    dynamic obj = JsonConvert.DeserializeObject(catalogo)!;
    //modifico l'oggetto dall'array
    List<dynamic> list = obj.ToObject<List<dynamic>>();

    string nome_Remove;
      
    Console.Write("\nInserisci il nome del prodotto da rimuovere dal catalogo: ");
    nome_Remove = Console.ReadLine()!;
    int pres = 0;
    for(int i = 0;i < list.Count; i++)
    {
        if(list[i].nome == nome_Remove)
        {
            list.RemoveAt(i);
            //serializzo l'array
            string jsonRemove = JsonConvert.SerializeObject(list, Formatting.Indented);
            //scrivo il file
            File.WriteAllText("catalogo.json", jsonRemove);
            Console.WriteLine($"Il prodotto {nome_Remove} è stato rimosso con successo dal catalogo");
            pres = 1;
        }
    } 

    if(pres == 0)
    {
        Console.WriteLine($"Il prodotto {nome_Remove} non è presente nel catalogo");
    }
}

//------------------------------------------Funzione visualizza Carrello------------------------------------------

static void VisualizzaProdottiCarrello()
{
    string path = @"Carrello.json"; // in questo caso il file è nella stessa cartella del programma
    string carrello = File.ReadAllText(path); //legge il file

    dynamic obj = JsonConvert.DeserializeObject(carrello)!; // deserializza il file

    //stampo il file
    foreach (var item in obj)
    {
        Console.WriteLine($"\nID:{item.ID} \nNome Prodotto:{item.nome} \nPrezzo:{item.prezzo} \nQuantità:{item.quantita}\n"); // stampa il file
    }
}

//------------------------------------------Funzione aggiungi prodotto al Carrello------------------------------------------

static void AggiungiAlCarrello()
{
    //leggo il file
    string catalogo = File.ReadAllText("catalogo.json");
    string carrello = File.ReadAllText("carrello.json");
    //deserializzo il file
    dynamic obj = JsonConvert.DeserializeObject(catalogo)!;
    dynamic carr = JsonConvert.DeserializeObject(carrello)!;
    //modifico l'oggetto dall'array
    List<dynamic> Catalogo = obj.ToObject<List<dynamic>>();
    List<dynamic> Carrello = carr.ToObject<List<dynamic>>();

    string nome_Add;
    string qta_Add;
    bool Presente = false;

        
    Console.Write("\nInserisci il nome del prodotto da aggiungere al carrello: ");
    nome_Add = Console.ReadLine()!;
    
    
    for(int i = 0;i < Catalogo.Count; i++)
    {
                if(Carrello[i].nome == nome_Add)
            {
                Console.Write($"\nIl prodotto {nome_Add} è già presente nel carrello in {Carrello[i].quantita}; \nVuoi modificare la quantità? (s/n)");
                char risposta = Console.ReadKey().KeyChar;
                if(risposta == 'S' || risposta == 's')
                {
                    Console.Write($"\nInserisci la quantità di {nome_Add} da modificare nel carrello: ");
                    qta_Add = Console.ReadLine()!;
                    Carrello[i].quantita = qta_Add;
                    Console.Write($"\nQuantità aggiornata");
                }
                if(risposta == 'N' || risposta == 'n')
                {
                    Console.Write($"\nLa quantità di {nome_Add} è rimasta invariata!");

                }
                if(risposta == 'N' || risposta == 'n' || risposta == 'S' || risposta == 's')
                {
                    Console.Write($"\nRisposta non valida!");
                    break;
                }
            }
        
        
        if(Catalogo[i].nome == nome_Add)
        {
            Presente = true;
            Console.Write($"\nInserisci la quantità di {nome_Add} da aggiungere al carrello: ");
            qta_Add = Console.ReadLine()!;
            var prova = new{ID = Catalogo[i].ID, nome = Catalogo[i].nome, quantita = qta_Add,prezzo = Catalogo[i].prezzo};
             string Inserimento  = JsonConvert.SerializeObject(prova, Formatting.Indented);
             File.WriteAllText("carrello.json", Inserimento);
        }
    }

    if(Presente == false)
    {
        Console.WriteLine($"Il prodotto {nome_Add} non è presente nel catalogo! \n Impossibile aggiungerlo al carrello!");
    }

}