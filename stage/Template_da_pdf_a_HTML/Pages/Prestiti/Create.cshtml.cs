using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages_Prestiti
{
    public class CreateModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;
        private readonly IConfiguration Configuration;
        public int LimiteLibri;
        public int GiorniScadenza;

        public CreateModel(Template_da_pdf_a_HTML.Data.RequestContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
            var limiteLibri = int.Parse(Configuration["LimitiBiblioteca:LimiteLibri"]);
            var giorniScadenza = int.Parse(Configuration["LimitiBiblioteca:ScadenzaPrestito"]);
            LimiteLibri = limiteLibri;
            GiorniScadenza = giorniScadenza;
        }

        public IActionResult OnGet()
        {
            ViewData["Libroid"] = new SelectList(_context.Libro.Where(p => p.Eliminato == false && p.Disponibile == true), "Id", "Titolo");
            ViewData["Utenteid"] = new SelectList(_context.Utente.Where(p => p.Eliminato == false), "Id", "Cognome");
            return Page();
        }

        [BindProperty]
        public Prestito Prestito { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            var LibroPrestito = _context.Libro.Where(l => l.Id == Prestito.LibroId).FirstOrDefault();
            var utente = _context.Utente.Where(u => u.Id == Prestito.UtenteId).FirstOrDefault();
            Prestito.DataInserimento = DateTime.Now.ToString("dd/MM/yy - H:mm:ss");
            Prestito.DataScadenzaPrestito = Prestito.DataInizioPrestito.AddDays(GiorniScadenza);
            TimeSpan range;
            int Counter;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var prestitiAttivi = _context.Prestito.Where(p => p.UtenteId == Prestito.UtenteId && p.Eliminato == false).ToList();
            
            foreach(var item in prestitiAttivi)
            {
                range = item.DataScadenzaPrestito - DateTime.Today;
                if (range.Days <= 0)
                {
                    return RedirectToPage("./Index", new {prestitoScaduto = true});
                }
            }

            Counter = prestitiAttivi.Count;

            if (Counter >= LimiteLibri)
            {
                Console.WriteLine("Limite Libri raggiunto");
            }
            else
            {
                LibroPrestito.Disponibile = false;
                
                _context.Libro.Update(LibroPrestito);
                _context.Prestito.Add(Prestito);
                await _context.SaveChangesAsync();
                Console.WriteLine($"Counter : {Counter}");
            }


            return RedirectToPage("./Index");
        }
    }
}
