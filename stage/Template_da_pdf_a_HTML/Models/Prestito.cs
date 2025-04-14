using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Prestiti")]
public class Prestito
{
    [Key]
    public int Id { get; set; }
    public DateTime DataInizioPrestito { get; set; }
    public DateTime DataScadenzaPrestito { get; set; }
    public string DataInserimento { get; set; }
    public string DataModifica { get; set; } = DateTime.Now.ToString("dd/MM/yyyy - H:mm:ss");
    public bool Eliminato { get; set; } = false;
    public bool Attivo { get; set; } = false;

    [ForeignKey("Utente")]
    public int UtenteId { get; set; }
    public Utente Utente { get; set; }
    
    [ForeignKey("Libro")]
    public int LibroId { get; set; }
    public Libro Libro { get; set; }
}