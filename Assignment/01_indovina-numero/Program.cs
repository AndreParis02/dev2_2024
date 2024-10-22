Random random = new Random();// Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101);// Next e il metodo che genera un numero casuale tra 1 e 100

Console.Clear();

Console.WriteLine("Indovina il numero (tra 1 e 100): ");

int numeroInserito;
int numTentativi = 5;

for(int i = 0; i < 5; i++)
{
    numTentativi --;
    numeroInserito = Convert.ToInt32(Console.ReadLine());

        if(numeroInserito != numeroDaIndovinare && numTentativi != 0)
        {
            if(numeroInserito < numeroDaIndovinare)
            {
                Console.WriteLine($"Il numero da indovinare e' maggiore, hai ancora {numTentativi} tentativi!");
                Console.WriteLine("Riprova: ");
            }else
            {
                Console.WriteLine($"Il numero da indovinare e' minore, hai ancora {numTentativi} tentativi!");
                Console.WriteLine("Riprova: ");
            }    
        }
        else if(numeroInserito == numeroDaIndovinare)
        {
            Console.WriteLine($"Hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}, indovinato con {numTentativi} tentativi!");
            i = 5;
        }   
    }    
if( numTentativi == 0)
{
    Console.WriteLine($"Peccato non hai indovinato! Il numero da indovinare era: {numeroDaIndovinare}");
}
    
   
        
        

    
