using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dos_modulos.Data;
using dos_modulos.Model;

namespace dos_modulos.Pages.examen
{
    public class CreateModel : PageModel
    {
        private readonly dos_modulos.Data.dos_modulosContext _context;

        public CreateModel(dos_modulos.Data.dos_modulosContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Examen Examen { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Examen.Add(Examen);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
