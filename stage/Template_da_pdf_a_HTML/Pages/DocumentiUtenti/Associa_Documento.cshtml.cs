using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.DocumentiUtenti
{
    public class Associa_documentoModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public Associa_documentoModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            ViewData["idTipo"] = new SelectList(_context.Tipo, "Id", "Nome");
            var utente = _context.Utente.FirstOrDefault(u => u.Id == id);
            if (utente != null)
            {
                Utente = utente;
            }
            return Page();
        }

        [BindProperty]
        public DocumentoUtente DocumentoUtente { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public Utente Utente { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model is not valid.");
                return Page();
            }

            // Imposta la data di inserimento
            DocumentoUtente.DataInserimento = DateTime.Now.ToString("dd/MM/yy - H:mm:ss");

            _context.DocumentoUtente.Add(DocumentoUtente);
            await _context.SaveChangesAsync();


            return RedirectToPage("/Utenti/Index");
        }


    }
}
