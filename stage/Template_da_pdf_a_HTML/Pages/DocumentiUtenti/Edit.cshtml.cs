using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.DocumentiUtenti
{
    public class EditModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public EditModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DocumentoUtente DocumentoUtente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["idTipo"] = new SelectList(_context.Tipo, "Id", "Nome");
            ViewData["idUtente"] = new SelectList(_context.Utente, "Id", "Cognome");
            if (id == null)
            {
                return NotFound();
            }

            var documentoutente =  await _context.DocumentoUtente.FirstOrDefaultAsync(m => m.Id == id);
            if (documentoutente == null)
            {
                return NotFound();
            }
            DocumentoUtente = documentoutente;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DocumentoUtente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentoUtenteExists(DocumentoUtente.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DocumentoUtenteExists(int id)
        {
            return _context.DocumentoUtente.Any(e => e.Id == id);
        }
    }
}
