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
    public class UnidadesController : Controller
    {
        private readonly ProjetoSisConBensContext _context;

        public UnidadesController(ProjetoSisConBensContext context)
        {
            _context = context;
        }

        // GET: Unidades
        public async Task<IActionResult> Index()
        {
            var projetoSisConBensContext = _context.Unidade.Include(u => u.Cidade);
            return View(await projetoSisConBensContext.ToListAsync());
        }

        // GET: Unidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Unidade == null)
            {
                return NotFound();
            }

            var unidade = await _context.Unidade
                .Include(u => u.Cidade)
                .FirstOrDefaultAsync(m => m.UnidadeId == id);
            if (unidade == null)
            {
                return NotFound();
            }

            return View(unidade);
        }

        // GET: Unidades/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome");
            return View();
        }

        // POST: Unidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnidadeId,UnidadeIdentificacao,UnidadeAtividades,UnidadeEndereco,UnidadeBairro,CidadeId,UnidadeCep")] Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome", unidade.CidadeId);
            return View(unidade);
        }

        // GET: Unidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Unidade == null)
            {
                return NotFound();
            }

            var unidade = await _context.Unidade.FindAsync(id);
            if (unidade == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome", unidade.CidadeId);
            return View(unidade);
        }

        // POST: Unidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnidadeId,UnidadeIdentificacao,UnidadeAtividades,UnidadeEndereco,UnidadeBairro,CidadeId,UnidadeCep")] Unidade unidade)
        {
            if (id != unidade.UnidadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadeExists(unidade.UnidadeId))
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
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome", unidade.CidadeId);
            return View(unidade);
        }

        // GET: Unidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Unidade == null)
            {
                return NotFound();
            }

            var unidade = await _context.Unidade
                .Include(u => u.Cidade)
                .FirstOrDefaultAsync(m => m.UnidadeId == id);
            if (unidade == null)
            {
                return NotFound();
            }

            return View(unidade);
        }

        // POST: Unidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Unidade == null)
            {
                return Problem("Entity set 'ProjetoSisConBensContext.Unidade'  is null.");
            }
            var unidade = await _context.Unidade.FindAsync(id);
            if (unidade != null)
            {
                _context.Unidade.Remove(unidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadeExists(int id)
        {
          return _context.Unidade.Any(e => e.UnidadeId == id);
        }
    }
}
