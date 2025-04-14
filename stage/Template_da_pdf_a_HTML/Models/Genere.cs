using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Generi")]
public class Genere
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public bool Eliminato { get; set; } = false;
    public ICollection<Libro> Libri { get; set; }
}