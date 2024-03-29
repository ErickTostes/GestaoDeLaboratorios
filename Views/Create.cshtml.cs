using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestaoDeLaboratorios.DAL;
using GestaoDeLaboratorios.Models;

namespace GestaoDeLaboratorios.Views
{
    public class CreateModel : PageModel
    {
        private readonly GestaoDeLaboratorios.DAL.InfnetDbContext _context;

        public CreateModel(GestaoDeLaboratorios.DAL.InfnetDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Computadores Computadores { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Computadores.Add(Computadores);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
