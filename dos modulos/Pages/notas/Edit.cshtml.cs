using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dos_modulos.Data;
using dos_modulos.Model;

namespace dos_modulos.Pages.notas
{
    public class EditModel : PageModel
    {
        private readonly dos_modulos.Data.dos_modulosContext _context;

        public EditModel(dos_modulos.Data.dos_modulosContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Notas Notas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notas =  await _context.Notas.FirstOrDefaultAsync(m => m.Id == id);
            if (notas == null)
            {
                return NotFound();
            }
            Notas = notas;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Notas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotasExists(Notas.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NotasExists(int id)
        {
            return _context.Notas.Any(e => e.Id == id);
        }
    }
}
