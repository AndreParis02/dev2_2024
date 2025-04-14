using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.DocumentiUtenti
{
    public class IndexModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public IndexModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }

        public IList<DocumentoUtente> DocumentoUtente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var documentiUtenti = from d in _context.DocumentoUtente where d.Eliminato == false select d;
            DocumentoUtente = await documentiUtenti.Include(d => d.Tipo).Include(d => d.Utente).ToListAsync();
        }
    }
}
