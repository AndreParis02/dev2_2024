using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Libri")]
public class Libro
{
    [Key]
    public int Id { get; set; }
    public string Titolo {get; set; }
    public DateOnly AnnoUscita { get; set; }
    public string DataInserimento { get; set; }
    public string DataModifica { get; set; } = DateTime.Now.ToString("dd/MM/yy - H:mm:ss");
    public bool Eliminato { get; set; }
    public bool Disponibile { get; set; } = true;

    [ForeignKey("Genere")]
    public int? idGenere { get; set; }
    public Genere Genere { get; set; }

    [ForeignKey("Autore")]
    public int? idAutore { get; set; }
    public Autore Autore { get; set; }
}