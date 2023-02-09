using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoSisConBens.Data;
using ProjetoSisConBens.Models;

namespace ProjetoSisConBens.Controllers
{
    public class ColaboradoresController : Controller
    {
        private readonly ProjetoSisConBensContext _context;

        public ColaboradoresController(ProjetoSisConBensContext context)
        {
            _context = context;
        }

        // GET: Colaboradores
        public async Task<IActionResult> Index()
        {
            var projetoSisConBensContext = _context.Colaborador.Include(c => c.Cargo).Include(c => c.Unidade);
            return View(await projetoSisConBensContext.ToListAsync());
        }

        // GET: Colaboradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Colaborador == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Cargo)
                .Include(c => c.Unidade)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // GET: Colaboradores/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "CargoDescricao");
            ViewData["UnidadeId"] = new SelectList(_context.Set<Unidade>(), "UnidadeId", "UnidadeAtividades");
            return View();
        }

        // POST: Colaboradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColaboradorId,ColaboradorRegistrofuncional,ColaboradorNome,ColaboradorRg,ColaboradorCpf,CargoId,UnidadeId")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaborador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "CargoDescricao", colaborador.CargoId);
            ViewData["UnidadeId"] = new SelectList(_context.Set<Unidade>(), "UnidadeId", "UnidadeAtividades", colaborador.UnidadeId);
            return View(colaborador);
        }

        // GET: Colaboradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colaborador == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "CargoDescricao", colaborador.CargoId);
            ViewData["UnidadeId"] = new SelectList(_context.Set<Unidade>(), "UnidadeId", "UnidadeAtividades", colaborador.UnidadeId);
            return View(colaborador);
        }

        // POST: Colaboradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColaboradorId,ColaboradorRegistrofuncional,ColaboradorNome,ColaboradorRg,ColaboradorCpf,CargoId,UnidadeId")] Colaborador colaborador)
        {
            if (id != colaborador.ColaboradorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorExists(colaborador.ColaboradorId))
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
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "CargoDescricao", colaborador.CargoId);
            ViewData["UnidadeId"] = new SelectList(_context.Set<Unidade>(), "UnidadeId", "UnidadeAtividades", colaborador.UnidadeId);
            return View(colaborador);
        }

        // GET: Colaboradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Colaborador == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Cargo)
                .Include(c => c.Unidade)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Colaborador == null)
            {
                return Problem("Entity set 'ProjetoSisConBensContext.Colaborador'  is null.");
            }
            var colaborador = await _context.Colaborador.FindAsync(id);
            if (colaborador != null)
            {
                _context.Colaborador.Remove(colaborador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorExists(int id)
        {
          return _context.Colaborador.Any(e => e.ColaboradorId == id);
        }
    }
}
