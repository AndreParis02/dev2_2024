using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages_Prestiti
{
    public class IndexModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public IndexModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        public IList<Prestito> Prestito { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public bool prestitoScaduto {get; set;} = false;

        public async Task OnGetAsync()
        {
            var prestiti = from p in _context.Prestito where p.Eliminato == false select p;
            
            Prestito = await prestiti
                .Include(p => p.Libro)
                .Include(p => p.Utente).ToListAsync();  
        }
    }
}
