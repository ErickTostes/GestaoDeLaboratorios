using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestaoDeLaboratorios.Models;

namespace GestaoDeLaboratorios.Views
{
    public class IndexModel : PageModel
    {
        private readonly DAL.InfnetDbContext _context;

        public IndexModel(DAL.InfnetDbContext context)
        {
            _context = context;
        }

        public IList<Computadores> Computadores { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Computadores = await _context.Computadores.ToListAsync();
        }
    }
}
