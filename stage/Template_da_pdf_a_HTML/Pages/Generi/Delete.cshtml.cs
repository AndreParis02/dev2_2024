using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Generi
{
    public class DeleteModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public DeleteModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Genere Genere { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public bool Allerta { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genere = await _context.Genere.FirstOrDefaultAsync(m => m.Id == id);
                        var libriAssociati = await _context.Libro.Where(p => p.idGenere == id).ToListAsync();
            bool genereInUso = libriAssociati.Any();

            if (genereInUso)
            {
                Allerta = true;
            }

            if (genere != null)
            {
                Genere = genere;
                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Se l'id è null, restituisci NotFound
            }

            var genere = await _context.Genere.FindAsync(id);

            if (genere == null)
            {
                return NotFound(); // Se il genere non è trovato, restituisci NotFound
            }

            // Verifica se esistono libri associati a questo genere
            var libriAssociati = await _context.Libro.Where(p => p.idGenere == id).ToListAsync();
            bool genereInUso = libriAssociati.Any();

            if (genereInUso)
            {
                foreach (var libro in libriAssociati)
                {
                    libro.idGenere = null;
                    _context.Libro.Update(libro);
                }

                // Segna il genere come eliminato
                genere.Eliminato = true;
                await _context.SaveChangesAsync();
                return RedirectToPage("./Delete", new { id, Allerta = true});
            }
            else
            {
                genere.Eliminato = true;
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }
    }


}
