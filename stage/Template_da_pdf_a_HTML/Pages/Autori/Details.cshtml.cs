using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Autori
{
    public class DetailsModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public DetailsModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        public Autore Autore { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.Autore.FirstOrDefaultAsync(m => m.Id == id);

            if (autore is not null)
            {
                Autore = autore;

                return Page();
            }

            return NotFound();
        }
    }
}
