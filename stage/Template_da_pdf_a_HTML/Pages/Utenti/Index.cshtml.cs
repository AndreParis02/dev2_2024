using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Utenti
{
    public class IndexModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public IndexModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public IList<Utente> Utente { get;set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {
             var utenti = from u in _context.Utente where u.Eliminato == false select u;
             
             
            Utente = await utenti.Include(u => u.DocumentoUtente).ToListAsync();
        }
    }
}
