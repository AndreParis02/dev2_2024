using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Utenti
{
    public class DeleteModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public DeleteModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Utente Utente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente.Include(u=> u.DocumentoUtente).FirstOrDefaultAsync(m => m.Id == id);

            if (utente is not null)
            {
                Utente = utente;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var utente = await _context.Utente.Include(u=> u.DocumentoUtente).FirstOrDefaultAsync(m => m.Id == id);
            var prestito = await _context.Prestito.Include(p => p.Libro).Where(p => p.UtenteId == id).ToListAsync();

            if (utente != null)
            {
                prestito.ForEach(p => p.Libro.Disponibile = true);

                Utente = utente;
                Utente.Eliminato = true;
                if(Utente.DocumentoUtente == null)
                {

                }
                else
                {
                    Utente.DocumentoUtente.Eliminato = true;
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
