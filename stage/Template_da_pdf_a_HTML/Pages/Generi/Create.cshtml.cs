using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Template_da_pdf_a_HTML.Data;

namespace Template_da_pdf_a_HTML.Pages.Generi
{
    public class CreateModel : PageModel
    {
        private readonly Template_da_pdf_a_HTML.Data.RequestContext _context;

        public CreateModel(Template_da_pdf_a_HTML.Data.RequestContext context)
        {
            _context = context;
        }
        public List<SelectListItem> GeneriSelectList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> AutoriSelectList { get; set; } = new List<SelectListItem>();


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Genere Genere { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Genere.Add(Genere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }


}






