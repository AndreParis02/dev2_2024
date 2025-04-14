using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Richieste
{
    public class DeleteModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public DeleteModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Richiesta Richiesta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var richiesta = await _context.Richieste.FirstOrDefaultAsync(m => m.Id == id);

            if (richiesta is not null)
            {
                Richiesta = richiesta;

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

            var richieste = from r in _context.Richieste select r;
            if(richieste!= null)
            {
                await richieste.Where (r => r.Id == id).ExecuteUpdateAsync(setters => setters.SetProperty(r => r.Cancellato, true));
                        
            }

            return RedirectToPage("./Index");
        }
    }
}
