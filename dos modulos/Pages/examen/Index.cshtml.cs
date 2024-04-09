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
    public class IndexModel : PageModel
    {
        private readonly dos_modulos.Data.dos_modulosContext _context;

        public IndexModel(dos_modulos.Data.dos_modulosContext context)
        {
            _context = context;
        }

        public IList<Examen> Examen { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Examen = await _context.Examen.ToListAsync();
        }
    }
}
