using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Richiesta
{
    public int Id { get; set; }
    [Required]
    [StringLength(40, MinimumLength = 5, ErrorMessage = "Inserisci un valore compreso tra i 5 e i 40 caratteri")]
    public string Nome { get; set; }

    [Required]
    [StringLength(40, MinimumLength = 5, ErrorMessage = "Inserisci un valore compreso tra i 5 e i 40 caratteri")]
    public string Cognome { get; set; }

    [Required]
    [StringLength(40, ErrorMessage = "Inserisci un valore massimo di 40 caratteri")]
    [EmailAddress(ErrorMessage = "Inserire una mail vailda")]
    public string Email { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 10, ErrorMessage = "Inserisci un valore compreso tra i 10 e i 60 caratteri")]
    public string Oggetto { get; set; }

    [Required]
    [MaxLength(200, ErrorMessage = "Inserisci un valore compreso tra i 5 e i 40 caratteri")]
    public string Messaggio { get; set; }
    public string Data_inserimento { get; set; } = DateTime.Now.ToString("dd/MM/yy H:mm:ss");
    public bool Cancellato { get; set; }
}