using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;

[Table("Utenti")]
public class Utente
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public DateOnly DataNascita { get; set; }
    public string DataInserimento { get; set; }  
    public string DataModifica { get; set; } = DateTime.Now.ToString("dd/MM/yy - H:mm:ss");
    public bool Eliminato { get; set; }

    public DocumentoUtente? DocumentoUtente { get; set; }
    public ICollection<Prestito>? Prestiti { get; set; } 
    

}