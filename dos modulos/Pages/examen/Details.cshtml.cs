using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dos_modulos.Data;
using dos_modulos.Model;

namespace dos_modulos.Pages.examen
{
    public class DetailsModel : PageModel
    {
        private readonly dos_modulos.Data.dos_modulosContext _context;

        public DetailsModel(dos_modulos.Data.dos_modulosContext context)
        {
            _context = context;
        }

        public Examen Examen { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examen = await _context.Examen.FirstOrDefaultAsync(m => m.Id == id);
            if (examen == null)
            {
                return NotFound();
            }
            else
            {
                Examen = examen;
            }
            return Page();
        }
    }
}
