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
    public class ComportamentoNegociosController : Controller
    {
        private readonly OracleDbContext _context;

        public ComportamentoNegociosController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: ComportamentoNegocios
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComportamentoNegocios.ToListAsync());
        }

        // GET: ComportamentoNegocios/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comportamentoNegocios = await _context.ComportamentoNegocios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comportamentoNegocios == null)
            {
                return NotFound();
            }

            return View(comportamentoNegocios);
        }

        // GET: ComportamentoNegocios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComportamentoNegocios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InteracoesPlataforma,FrequenciaUso,Feedback,UsoRecursosEspecificos")] ComportamentoNegocios comportamentoNegocios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comportamentoNegocios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comportamentoNegocios);
        }

        // GET: ComportamentoNegocios/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comportamentoNegocios = await _context.ComportamentoNegocios.FindAsync(id);
            if (comportamentoNegocios == null)
            {
                return NotFound();
            }
            return View(comportamentoNegocios);
        }

        // POST: ComportamentoNegocios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,InteracoesPlataforma,FrequenciaUso,Feedback,UsoRecursosEspecificos")] ComportamentoNegocios comportamentoNegocios)
        {
            if (id != comportamentoNegocios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comportamentoNegocios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComportamentoNegociosExists(comportamentoNegocios.Id))
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
            return View(comportamentoNegocios);
        }

        // GET: ComportamentoNegocios/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comportamentoNegocios = await _context.ComportamentoNegocios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comportamentoNegocios == null)
            {
                return NotFound();
            }

            return View(comportamentoNegocios);
        }

        // POST: ComportamentoNegocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var comportamentoNegocios = await _context.ComportamentoNegocios.FindAsync(id);
            if (comportamentoNegocios != null)
            {
                _context.ComportamentoNegocios.Remove(comportamentoNegocios);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComportamentoNegociosExists(long id)
        {
            return _context.ComportamentoNegocios.Any(e => e.Id == id);
        }
    }
}
