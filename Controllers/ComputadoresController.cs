using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoDeLaboratorios.DAL;
using GestaoDeLaboratorios.Models;

namespace GestaoDeLaboratorios.Controllers
{
    public class ComputadoresController : Controller
    {
        private readonly InfnetDbContext _context;

        public ComputadoresController(InfnetDbContext context)
        {
            _context = context;
        }

        // GET: Computadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Computadores.ToListAsync());
        }

        // GET: Computadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computadores = await _context.Computadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computadores == null)
            {
                return NotFound();
            }

            return View(computadores);
        }

        // GET: Computadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Computadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Processador,PlacaMae,Memoria,HD,NumeroPatrimonio,DataCompra")] Computadores computadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(computadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(computadores);
        }

        // GET: Computadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computadores = await _context.Computadores.FindAsync(id);
            if (computadores == null)
            {
                return NotFound();
            }
            return View(computadores);
        }

        // POST: Computadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Processador,PlacaMae,Memoria,HD,NumeroPatrimonio,DataCompra")] Computadores computadores)
        {
            if (id != computadores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputadoresExists(computadores.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(computadores);
        }

        // GET: Computadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computadores = await _context.Computadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computadores == null)
            {
                return NotFound();
            }

            return View(computadores);
        }

        // POST: Computadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var computadores = await _context.Computadores.FindAsync(id);
            if (computadores != null)
            {
                _context.Computadores.Remove(computadores);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputadoresExists(int id)
        {
            return _context.Computadores.Any(e => e.Id == id);
        }
    }
}
