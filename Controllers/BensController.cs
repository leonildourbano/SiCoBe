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
    public class BensController : Controller
    {
        private readonly ProjetoSisConBensContext _context;

        public BensController(ProjetoSisConBensContext context)
        {
            _context = context;
        }

        // GET: Bens
        public async Task<IActionResult> Index()
        {
            var projetoSisConBensContext = _context.Bem.Include(b => b.Inventario).Include(b => b.Unidade);
            return View(await projetoSisConBensContext.ToListAsync());
        }

        // GET: Bens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bem == null)
            {
                return NotFound();
            }

            var bem = await _context.Bem
                .Include(b => b.Inventario)
                .Include(b => b.Unidade)
                .FirstOrDefaultAsync(m => m.BemId == id);
            if (bem == null)
            {
                return NotFound();
            }

            return View(bem);
        }

        // GET: Bens/Create
        public IActionResult Create()
        {
            ViewData["InventarioId"] = new SelectList(_context.Inventario, "InventarioId", "InventarioDescricao");
            ViewData["UnidadeId"] = new SelectList(_context.Unidade, "UnidadeId", "UnidadeAtividades");
            return View();
        }

        // POST: Bens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BemId,BemDescricao,BemDataaquisicao,BemValoraquisicao,BemImagem,BemStatus,BemDatastatus,UnidadeId,InventarioId")] Bem bem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InventarioId"] = new SelectList(_context.Inventario, "InventarioId", "InventarioDescricao", bem.InventarioId);
            ViewData["UnidadeId"] = new SelectList(_context.Unidade, "UnidadeId", "UnidadeAtividades", bem.UnidadeId);
            return View(bem);
        }

        // GET: Bens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bem == null)
            {
                return NotFound();
            }

            var bem = await _context.Bem.FindAsync(id);
            if (bem == null)
            {
                return NotFound();
            }
            ViewData["InventarioId"] = new SelectList(_context.Inventario, "InventarioId", "InventarioDescricao", bem.InventarioId);
            ViewData["UnidadeId"] = new SelectList(_context.Unidade, "UnidadeId", "UnidadeAtividades", bem.UnidadeId);
            return View(bem);
        }

        // POST: Bens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BemId,BemDescricao,BemDataaquisicao,BemValoraquisicao,BemImagem,BemStatus,BemDatastatus,UnidadeId,InventarioId")] Bem bem)
        {
            if (id != bem.BemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BemExists(bem.BemId))
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
            ViewData["InventarioId"] = new SelectList(_context.Inventario, "InventarioId", "InventarioDescricao", bem.InventarioId);
            ViewData["UnidadeId"] = new SelectList(_context.Unidade, "UnidadeId", "UnidadeAtividades", bem.UnidadeId);
            return View(bem);
        }

        // GET: Bens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bem == null)
            {
                return NotFound();
            }

            var bem = await _context.Bem
                .Include(b => b.Inventario)
                .Include(b => b.Unidade)
                .FirstOrDefaultAsync(m => m.BemId == id);
            if (bem == null)
            {
                return NotFound();
            }

            return View(bem);
        }

        // POST: Bens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bem == null)
            {
                return Problem("Entity set 'ProjetoSisConBensContext.Bem'  is null.");
            }
            var bem = await _context.Bem.FindAsync(id);
            if (bem != null)
            {
                _context.Bem.Remove(bem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BemExists(int id)
        {
          return _context.Bem.Any(e => e.BemId == id);
        }
    }
}
