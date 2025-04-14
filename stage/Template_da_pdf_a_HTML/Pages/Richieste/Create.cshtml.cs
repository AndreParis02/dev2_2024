using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Richieste
{
    public class CreateModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public CreateModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Nome { get; set; }


        [BindProperty]
        public string Cognome { get; set; }


        [BindProperty]
        
        public string Email { get; set; }


        [BindProperty]
        
        public string Oggetto { get; set; }

        [BindProperty]
        public string Messaggio { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Richiesta Richiesta { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Richieste.Add(Richiesta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
