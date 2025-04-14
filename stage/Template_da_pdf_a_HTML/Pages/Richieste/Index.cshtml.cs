using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Template_da_pdf_a_HTML.Data;
using ContosoUniversity;

namespace Template_da_pdf_a_HTML.Pages.Richieste
{
    public class IndexModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        private readonly IConfiguration Configuration;

        public IndexModel(RequestContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string EmailSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public PaginatedList<Richiesta> Richiesta { get; set; }
        public async Task OnGetAsync(string searchString, string currentFilter, string sortOrder, int? pageIndex)
        {
            CurrentSort = sortOrder;
            EmailSort = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
             if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter=searchString;

            IQueryable<Richiesta> richieste = from r in _context.Richieste where r.Cancellato == false select r;

            if (!string.IsNullOrEmpty(searchString))
            {
                richieste = richieste.Where(r => r.Nome.Contains(searchString)
                                       || r.Cognome.Contains(searchString) || r.Email.Contains(searchString) || r.Oggetto.Contains(searchString) || r.Messaggio.Contains(searchString) && r.Cancellato == false);
            }

            switch (sortOrder)
            {
                case "email_desc":
                    richieste = richieste.OrderByDescending(r => r.Email);
                    break;
                case "Date":
                    richieste = richieste.OrderBy(r => r.Data_inserimento);
                    break;
                case "date_desc":
                    richieste = richieste.OrderByDescending(r => r.Data_inserimento);
                    break;
                default:
                    richieste = richieste.OrderBy(r => r.Email);
                    break;
            }
            
            var pageSize = Configuration.GetValue("PageSize", 4);
            Richiesta = await PaginatedList<Richiesta>.CreateAsync(
                richieste.AsNoTracking(), pageIndex ?? 1, pageSize);
        }


    }
}
