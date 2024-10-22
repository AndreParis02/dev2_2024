Random random = new Random();// Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101);// Next e il metodo che genera un numero casuale tra 1 e 100

Console.Clear();

Console.WriteLine("Indovina il numero (tra 1 e 100): ");

int numeroInserito;
int totPunti = 100;
int numPunti = totPunti;

for(int i = 0; i < (totPunti/5); i++)
{
    numeroInserito = Convert.ToInt32(Console.ReadLine());
    numPunti -= 5;

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
    
   
        
        

    
