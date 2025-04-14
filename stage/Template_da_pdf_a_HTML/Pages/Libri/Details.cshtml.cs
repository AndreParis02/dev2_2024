using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Libri
{
    public class DetailsModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public DetailsModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        public Libro Libro { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libro.Include(l => l.Genere).Include(l => l.Autore).FirstOrDefaultAsync(m => m.Id == id);

            if (libro is not null)
            {
                Libro = libro;

                return Page();
            }

            return NotFound();
        }
    }
}
