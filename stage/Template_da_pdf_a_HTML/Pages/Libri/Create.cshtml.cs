using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Libri
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
        ViewData["idAutore"] = new SelectList(_context.Autore.Where(l=> l.Eliminato == false), "Id", "Cognome");
        ViewData["idGenere"] = new SelectList(_context.Genere.Where(l=> l.Eliminato == false), "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public Libro Libro { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var libro = from l in _context.Libro select l;
            if(libro!= null && Libro.idGenere != null)
            {
                Libro.DataInserimento = DateTime.Now.ToString("dd/MM/yy - H:mm:ss");    
            }

            _context.Libro.Add(Libro);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
