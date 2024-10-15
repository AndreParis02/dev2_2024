// CONDIZIONI
/* 
le principali istruzioni di controllo sono:
    - if;
    -else;
    -else if;
    -switch;
*/

//pulisce la console
using System.Security.Cryptography.X509Certificates;

Console.Clear();
//ESEMPIO DI IF
//se una condizione viene soddisfatta esegue un blocco di codice
int v = 10;
if(v > 5)
{
    Console.WriteLine("v e' maggiore di 5");
}

//ESEMPIO D IF ELSE
//se una condizione viene soddisfatta eseguo un blocco di codice altrimenti ne eseguo un'altra
int w = 1;
if(w > 5)
{
    Console.WriteLine("w e' maggiore di 5");
}
else
{
    Console.WriteLine("w e' minore o uguale a 5");
}

//ESEMPIO DI IF ELSE IF
//se ua condizione viene soddisfatta esegue un blocco di codice altrimenti un altro se nessuna e' vera
int x = 5;
if(x > 5)
{
    Console.WriteLine("x e' maggiore di 5");
}
else if(x == 5)
{
    Console.WriteLine("x e' uguale 5");
}
else    
{
    Console.WriteLine("w e' minore di 5");
}
//else if va messo tra if e else perchè se messo dopo else non verrebbe mai eseguito