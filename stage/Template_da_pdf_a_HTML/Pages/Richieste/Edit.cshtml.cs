using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Richieste
{
    public class EditModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public EditModel(Template_da_pdf_a_HTML.Data.RequestContext context)
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

            var richiesta =  await _context.Richieste.FirstOrDefaultAsync(m => m.Id == id);
            if (richiesta == null)
            {
                return NotFound();
            }
            Richiesta = richiesta;
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

            _context.Attach(Richiesta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RichiestaExists(Richiesta.Id))
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

        private bool RichiestaExists(int id)
        {
            return _context.Richieste.Any(e => e.Id == id);
        }
    }
}
