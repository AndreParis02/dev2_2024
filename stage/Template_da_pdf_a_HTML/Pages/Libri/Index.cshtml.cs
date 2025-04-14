using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Libri
{
    public class IndexModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public IndexModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        public IList<Libro> Libro { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var libri = from l in _context.Libro where l.Eliminato == false select l;


            Libro = await libri
            .Include(l => l.Genere)
                .Include(l => l.Autore)
                .ToListAsync();
        }
    }
}
