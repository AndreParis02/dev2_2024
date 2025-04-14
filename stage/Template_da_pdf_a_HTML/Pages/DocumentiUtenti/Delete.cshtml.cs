using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.DocumentiUtenti
{
    public class DeleteModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public DeleteModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DocumentoUtente DocumentoUtente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentoutente = await _context.DocumentoUtente.FirstOrDefaultAsync(m => m.Id == id);

            if (documentoutente is not null)
            {
                DocumentoUtente = documentoutente;

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

            var documentoutente = await _context.DocumentoUtente.FindAsync(id);
            if (documentoutente != null)
            {
                documentoutente.Eliminato = true;
                DocumentoUtente = documentoutente;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
