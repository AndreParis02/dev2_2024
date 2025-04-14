using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("DocumentiUtenti")]
public class DocumentoUtente
{

    [Key]
    public int Id { get; set; }
    public string Numero { get; set; }
    public DateOnly Scadenza { get; set; }
    public string DataInserimento { get; set; }
    public string DataModifica { get; set; }= DateTime.Now.ToString("dd/MM/yy - H:mm:ss");
    public bool Eliminato { get; set; } = false;

        [ForeignKey("Utente")]
    public int idUtente { get; set; }
    public Utente Utente { get; set; }

    [ForeignKey("Tipo")]
    public int idTipo { get; set; }
     public Tipo Tipo { get; set; }
}