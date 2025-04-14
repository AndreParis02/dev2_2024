using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.DocumentiUtenti
{
    public class CreateModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public CreateModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["idTipo"] = new SelectList(_context.Tipo, "Id", "Nome");
            ViewData["idUtente"] = new SelectList(_context.Utente.Where(u=> u.Eliminato == false && u.DocumentoUtente == null), "Id", "Cognome");
            return Page();
        }

        [BindProperty]
        public DocumentoUtente DocumentoUtente { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var documentoUtente = from u in _context.DocumentoUtente select u;
            if(documentoUtente!= null)
            {
                DocumentoUtente.DataInserimento = DateTime.Now.ToString("dd/MM/yy - H:mm:ss");    
            }

            _context.DocumentoUtente.Add(DocumentoUtente);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Utenti/Index");
        }
    }
}
