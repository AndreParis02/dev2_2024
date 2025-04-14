using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Autori")]
public class Autore {
    [Key]
    public int Id {get;set;}
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public DateOnly DataNascita {get; set;}
    public DateOnly? DataMorte {get; set;}
    public bool Eliminato {get; set;}

    public ICollection<Libro> Libri {get; set;}
}