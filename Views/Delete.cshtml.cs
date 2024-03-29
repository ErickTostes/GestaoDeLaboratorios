using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestaoDeLaboratorios.Models;

namespace GestaoDeLaboratorios.Views
{
    public class DeleteModel : PageModel
    {
        private readonly GestaoDeLaboratorios.DAL.InfnetDbContext _context;

        public DeleteModel(GestaoDeLaboratorios.DAL.InfnetDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Computadores Computadores { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computadores = await _context.Computadores.FirstOrDefaultAsync(m => m.Id == id);

            if (computadores == null)
            {
                return NotFound();
            }
            else
            {
                Computadores = computadores;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computadores = await _context.Computadores.FindAsync(id);
            if (computadores != null)
            {
                Computadores = computadores;
                _context.Computadores.Remove(Computadores);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
