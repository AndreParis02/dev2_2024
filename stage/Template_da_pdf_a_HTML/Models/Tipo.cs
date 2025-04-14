using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Tipi")]
public class Tipo
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<DocumentoUtente> DocumentiUtenti { get; set; }

}