using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Generi
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
        public IList<Genere> Genere { get;set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            var generi = from g in _context.Genere where g.Eliminato == false select g;

            if (!string.IsNullOrEmpty(searchString))
            {
                generi = generi.Where(r => r.Nome.Contains(searchString) && r.Eliminato == false);
            }
            
            Genere = await generi.ToListAsync();
        }
    }
}
