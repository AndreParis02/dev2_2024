using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Utenti
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
            return Page();
        }

        [BindProperty]
        public Utente Utente { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var utente = from u in _context.Utente select u;
            if(utente!= null)
            {
                Utente.DataInserimento = DateTime.Now.ToString("dd/MM/yy - H:mm:ss");    
            }
            

            _context.Utente.Add(Utente);
            await _context.SaveChangesAsync();

            return RedirectToPage("/DocumentiUtenti/Create");
        }
    }
}
