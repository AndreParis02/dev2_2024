using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages_Prestiti
{
    public class DeleteModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public DeleteModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prestito Prestito { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestito = await _context.Prestito
                                          .Include(p => p.Utente)
                                          .Include(p => p.Libro)
                                          .FirstOrDefaultAsync(m => m.Id == id);

            if (prestito != null)
            {
                Prestito = prestito;
                return Page();
            }

            return NotFound();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Se id è null, restituisci NotFound
            }

            // Recupera il prestito associato all'ID
            var prestito = await _context.Prestito
                                         .Include(p => p.Libro)
                                         .Include(p => p.Utente)
                                         .FirstOrDefaultAsync(p => p.Id == id);

            if (prestito == null)
            {
                return NotFound(); // Se prestito è null, restituisci NotFound
            }

            // Recupera il libro associato al prestito
            var LibroPrestito = await _context.Libro
                                              .Where(l => l.Id == prestito.LibroId) // Usa prestito.LibroId anziché id
                                              .FirstOrDefaultAsync();

            if (LibroPrestito == null)
            {
                return NotFound(); // Se LibroPrestito è null, restituisci NotFound
            }

            // Ora possiamo sicuri che entrambi prestito e LibroPrestito non sono null
            LibroPrestito.Disponibile = true; // Imposta Disponibile su true
            prestito.Eliminato = true; // Imposta Eliminato su true

            // Salva le modifiche nel contesto
            _context.Libro.Update(LibroPrestito);
            await _context.SaveChangesAsync();

            // Reindirizza alla pagina Index
            return RedirectToPage("./Index");
        }

    }
}
