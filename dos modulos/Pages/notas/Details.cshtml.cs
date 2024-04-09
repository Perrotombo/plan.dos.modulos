using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dos_modulos.Data;
using dos_modulos.Model;

namespace dos_modulos.Pages.notas
{
    public class DetailsModel : PageModel
    {
        private readonly dos_modulos.Data.dos_modulosContext _context;

        public DetailsModel(dos_modulos.Data.dos_modulosContext context)
        {
            _context = context;
        }

        public Notas Notas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notas = await _context.Notas.FirstOrDefaultAsync(m => m.Id == id);
            if (notas == null)
            {
                return NotFound();
            }
            else
            {
                Notas = notas;
            }
            return Page();
        }
    }
}
