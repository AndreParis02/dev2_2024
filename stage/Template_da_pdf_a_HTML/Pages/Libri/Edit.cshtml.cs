using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Libri
{
    public class EditModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public EditModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Libro Libro { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro =  await _context.Libro.FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }
            Libro = libro;
           ViewData["idAutore"] = new SelectList(_context.Autore.Where(l=> l.Eliminato == false), "Id", "Cognome");
           ViewData["idGenere"] = new SelectList(_context.Genere.Where(l=> l.Eliminato == false), "Id", "Nome");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var genere = _context.Genere.Where(l=> l.Id == Libro.idGenere).FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Libro).State = EntityState.Modified;


                await _context.SaveChangesAsync();
           
            return RedirectToPage("./Index");
        }

        private bool LibroExists(int id)
        {
            return _context.Libro.Any(e => e.Id == id);
        }
    }
}
