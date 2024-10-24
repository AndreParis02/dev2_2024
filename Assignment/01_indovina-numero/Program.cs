Random random = new Random();
int numeroInserito;
int totPunti;
int numPunti;
int numeroDaIndovinare;

List <int> tentativiUtente = new List<int>(); //creo una lista per memoriazzare i tentativi dell'utente


Console.Clear();

Console.WriteLine("scegli il livello di difficolta':");
Console.WriteLine("difficoltà facile (f) Indovina il numero (tra 1 e 50),20 tentativi, 100 punti totali");
Console.WriteLine("difficoltà media (m) Indovina il numero (tra 1 e 100),10 tentativi, 100 punti totali");
Console.WriteLine("difficoltà difficile (d) Indovina il numero (tra 1 e 500),5 tentativi, 500 punti totali");
Console.WriteLine("difficoltà impossibile (i) Indovina il numero (tra 1 e 1000),5 tentativi, 1000 punti totali");

string difficoltà = Console.ReadLine();
switch (difficoltà)
{
    case "f":
        Console.WriteLine("Hai scelto la modalità facile");

        numeroDaIndovinare = random.Next(1, 51);

        Console.WriteLine("Indovina il numero (tra 1 e 50): ");

        totPunti = 100;
        numPunti = totPunti;


        for(int i = 0; i < (totPunti/5); i++)
        {
            numeroInserito = Convert.ToInt32(Console.ReadLine());
            numPunti -= 5;
            tentativiUtente.Add(numeroInserito);

                if(numeroInserito != numeroDaIndovinare && numPunti != 0)
                {
                    if(numeroInserito < numeroDaIndovinare)
                    {
                        Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }else
                    {
                        Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }    
                }
                else if(numeroInserito == numeroDaIndovinare)
                {
                    Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numPunti} punti!");
                    i = totPunti/5;
                }   
                
            }    
        if( numPunti == 0)
        {
            Console.WriteLine($"Peccato non hai indovinato ed hai finito tutti i punti! Il numero da indovinare era: {numeroDaIndovinare}");
        }
        break;

    case "m":
        
         Console.WriteLine("Hai scelto la modalità media");

        numeroDaIndovinare = random.Next(1, 101);

        Console.WriteLine("Indovina il numero (tra 1 e 100): ");

        totPunti = 100;
        numPunti = totPunti;


        for(int i = 0; i < (totPunti/10); i++)
        {
            numeroInserito = Convert.ToInt32(Console.ReadLine());
            numPunti -= 10;
            tentativiUtente.Add(numeroInserito);

                if(numeroInserito != numeroDaIndovinare && numPunti != 0)
                {
                    if(numeroInserito < numeroDaIndovinare)
                    {
                        Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }else
                    {
                        Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }    
                }
                else if(numeroInserito == numeroDaIndovinare)
                {
                    Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numPunti} punti!");
                    i = totPunti/10;
                }   
                
            }    
        if( numPunti == 0)
        {
            Console.WriteLine($"Peccato non hai indovinato ed hai finito tutti i punti! Il numero da indovinare era: {numeroDaIndovinare}");
        }

        break;

         case "d":
        
         Console.WriteLine("Hai scelto la modalità difficile");

        numeroDaIndovinare = random.Next(1, 501);

        Console.WriteLine("Indovina il numero (tra 1 e 500): ");

        totPunti = 500;
        numPunti = totPunti;


        for(int i = 0; i < (totPunti/100); i++)
        {
            numeroInserito = Convert.ToInt32(Console.ReadLine());
            numPunti -= 100;
            tentativiUtente.Add(numeroInserito);

                if(numeroInserito != numeroDaIndovinare && numPunti != 0)
                {
                    if(numeroInserito < numeroDaIndovinare)
                    {
                        Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }else
                    {
                        Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }    
                }
                else if(numeroInserito == numeroDaIndovinare)
                {
                    Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numPunti} punti!");
                    i = totPunti/100;
                }   
                
            }    
        if( numPunti == 0)
        {
            Console.WriteLine($"Peccato non hai indovinato ed hai finito tutti i punti! Il numero da indovinare era: {numeroDaIndovinare}");
        }

        break;

         case "i":
        
         Console.WriteLine("Hai scelto la modalità impossibile");

        numeroDaIndovinare = random.Next(1, 1001);

        Console.WriteLine("Indovina il numero (tra 1 e 1000): ");

        totPunti = 1000;
        numPunti = totPunti;


        for(int i = 0; i < (totPunti/200); i++)
        {
            numeroInserito = Convert.ToInt32(Console.ReadLine());
            numPunti -= 200;
            tentativiUtente.Add(numeroInserito);

                if(numeroInserito != numeroDaIndovinare && numPunti != 0)
                {
                    if(numeroInserito < numeroDaIndovinare)
                    {
                        Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }else
                    {
                        Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numPunti} punti!");
                        Console.WriteLine("Riprova: ");
                    }    
                }
                else if(numeroInserito == numeroDaIndovinare)
                {
                    Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numPunti} punti!");
                    i = totPunti/200;
                }   
                
            }    
        if( numPunti == 0)
        {
            Console.WriteLine($"Peccato non hai indovinato ed hai finito tutti i punti! Il numero da indovinare era: {numeroDaIndovinare}");
        }

        break;

    default:
        Console.WriteLine("non hai selezionato nessun livello di difficoltà!");
        break;
}

Console.WriteLine("tentativi effettuati: ");
foreach(int tentativo in tentativiUtente)
{
    Console.Write($"{tentativo} "); //stampo i tentativi effettuati
}