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
    public class DetailsModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public DetailsModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        public Utente Utente { get; set; } = default!;
        public List<Prestito> PrestitiAttivi {get; set; } = default!;
        public List<Prestito> Storico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente.Include(u => u.DocumentoUtente).FirstOrDefaultAsync(m => m.Id == id);
            PrestitiAttivi = _context.Prestito.Include(u => u.Libro).Where( p => p.UtenteId == id && p.Eliminato == false).ToList();
            Storico = _context.Prestito.Include(u => u.Libro).Where( p => p.UtenteId == id && p.Eliminato == true).ToList();


            if (utente is not null)
            {
                Utente = utente;

                return Page();
            }

            return NotFound();
        }
    }
}
