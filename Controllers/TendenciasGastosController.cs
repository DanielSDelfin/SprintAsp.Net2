using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprint2.Models;
using Sprint2.Persistence;

namespace Sprint2.Controllers
{
    public class TendenciasGastosController : Controller
    {
        private readonly OracleDbContext _context;

        public TendenciasGastosController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: TendenciasGastos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TendenciasGastos.ToListAsync());
        }

        // GET: TendenciasGastos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tendenciasGastos = await _context.TendenciasGastos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tendenciasGastos == null)
            {
                return NotFound();
            }

            return View(tendenciasGastos);
        }

        // GET: TendenciasGastos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TendenciasGastos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ano,GastoMarketing,GastoAutomacao")] TendenciasGastos tendenciasGastos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tendenciasGastos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tendenciasGastos);
        }

        // GET: TendenciasGastos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tendenciasGastos = await _context.TendenciasGastos.FindAsync(id);
            if (tendenciasGastos == null)
            {
                return NotFound();
            }
            return View(tendenciasGastos);
        }

        // POST: TendenciasGastos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Ano,GastoMarketing,GastoAutomacao")] TendenciasGastos tendenciasGastos)
        {
            if (id != tendenciasGastos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tendenciasGastos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TendenciasGastosExists(tendenciasGastos.Id))
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
            return View(tendenciasGastos);
        }

        // GET: TendenciasGastos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tendenciasGastos = await _context.TendenciasGastos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tendenciasGastos == null)
            {
                return NotFound();
            }

            return View(tendenciasGastos);
        }

        // POST: TendenciasGastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tendenciasGastos = await _context.TendenciasGastos.FindAsync(id);
            if (tendenciasGastos != null)
            {
                _context.TendenciasGastos.Remove(tendenciasGastos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TendenciasGastosExists(long id)
        {
            return _context.TendenciasGastos.Any(e => e.Id == id);
        }
    }
}
