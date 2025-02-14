using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; //in modo da usare SelectListItem
using System.Data.SQLite;

namespace _37_WebApp_SQLite.Pages.Prodotti;
using _37_WebApp_SQLite.Models;
public class ModificaModel : PageModel
{
    [BindProperty]
    public Prodotto Prodotto { get; set; }
    public List<SelectListItem> CategorieSelectList { get; set; } = new List<SelectListItem>();
    //passo l'id come parametro perchè voglio modificare un prodotto esistente sul quale ho cliccato in precedenza
    public IActionResult OnGet(int id)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        //uso la clausola WHERE di sql in modo da ottenere solo il prodotto con l'id passato come parametro
        var sql = "SELECT Id, Nome, Prezzo, CategoriaId FROM Prodotti WHERE Id = @id";
        using var command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        //eseguo il comando e ottengo un reader che è un oggetto che mi permette di leggere i dati
        using var reader = command.ExecuteReader();

        //se il reader ha dati
        if (reader.Read())
        {
            //aggiungo i dati del prodotto al modello 
            Prodotto = new Prodotto
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                IdCategoria = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
            };
        }
        else
        {
            //se il prodotto non esiste ritorno not found
            //not found è un metodo di page model che restituisce un oggetto not found result che rappresenta la pagina non trovata
            return NotFound();
        }
        //carico le categorie in modo da poterle visualizzare nella select list
        CaricaCategorie();
        //restituisco la pagina con i dati del prodotto da modificare

        return Page();
    }

    public IActionResult OnPost()
    {
        if(!ModelState.IsValid)
        {
            //se il modello non è valido carico le categorie e restituisco la pagina
            CaricaCategorie();
            return Page();
        }

        //invoco il metodo GetConnection per ottenere la connessione al DB ed apro la connessione
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        //costriusco la query basandomi sull'input
        var sql = "UPDATE Prodotti SET Nome = @nome, Prezzo = @prezzo, CategoriaId = @categoria WHERE Id = @id";
        using var command = new SQLiteCommand(sql,connection);
        command.Parameters.AddWithValue("@nome", Prodotto.Nome);
        command.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
        command.Parameters.AddWithValue("@categoria", Prodotto.IdCategoria);
        command.Parameters.AddWithValue("@id", Prodotto.Id);

        //eseguo il comando e aggiorno il prodotto poi reinderizzo alla pagina di elenco dei prodotti
        command.ExecuteNonQuery();
        return RedirectToPage("Index");
    }

    //metodo per caricare le categorie
    private void CaricaCategorie()
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        //creo la query sql per ottenre i dati dalle categorie
        var sql = "SELECT Id, Nome FROM Categorie";

        //creo un comando per eseguire la query
        using var command = new SQLiteCommand(sql, connection);
        //eseguo il comando e ottengo un reader che è un oggetto che mi permette di leggere i dati
        using var reader = command.ExecuteReader();
        //finche il reader ha dati
        while (reader.Read())
        {
            CategorieSelectList.Add(new SelectListItem
            {
                Value = reader.GetInt32(0).ToString(),  //converto in stringa l'id così da poterlo usare come valore
                Text = reader.GetString(1)
            });
        }
    }
}