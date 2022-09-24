using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using programa_consultorio.Data;
using programa_consultorio.Models;

namespace programa_consultorio.Controllers
{
    public class TarefasController : Controller
    {
        private readonly Contexto _context;

        public TarefasController(Contexto context)
        {
            _context = context;
        }

        // GET: Tarefas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tarefas.OrderByDescending(p => p.ordem_apres).ToListAsync());

        }

       
      

    // GET: Tarefas/Details/5
    public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas
                .FirstOrDefaultAsync(m => m.id_tarefa == id);
            if (tarefas == null)
            {
                return NotFound();
            }

            return View(tarefas);
        }

        // GET: Tarefas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_tarefa,nome_tarefa,custo_tarefa,data_limite,ordem_apres")] Tarefas tarefas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarefas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefas);
        }

        // GET: Tarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas.FindAsync(id);
            if (tarefas == null)
            {
                return NotFound();
            }
            return View(tarefas);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_tarefa,nome_tarefa,custo_tarefa,data_limite,ordem_apres")] Tarefas tarefas)
        {
            if (id != tarefas.id_tarefa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefasExists(tarefas.id_tarefa))
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
            return View(tarefas);
        }

        // GET: Tarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas
                .FirstOrDefaultAsync(m => m.id_tarefa == id);
            if (tarefas == null)
            {
                return NotFound();
            }

            return View(tarefas);
        }

        public async Task<IActionResult> MoveUP(int? id)
        {
            var tarefas = await _context.Tarefas.FindAsync(id);
            if(tarefas.ordem_apres == 1)
            {
                return NotFound();
            }
            else
            {
                tarefas.ordem_apres = tarefas.ordem_apres - 1;
            }
            return View(tarefas);
        }

        public async Task<IActionResult> MoveDOWN(int? id)
        {
            var tarefas = await _context.Tarefas.FindAsync(id);
            
            if (tarefas.ordem_apres == _context.Tarefas.Last().ordem_apres)
            {
                return NotFound();
            }
            else
            {
                tarefas.ordem_apres = tarefas.ordem_apres + 1;
            }
            return View(tarefas);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tarefas == null)
            {
                return Problem("Entity set 'Contexto.Tarefas'  is null.");
            }
            var tarefas = await _context.Tarefas.FindAsync(id);
            if (tarefas != null)
            {
                _context.Tarefas.Remove(tarefas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarefasExists(int id)
        {
          return _context.Tarefas.Any(e => e.id_tarefa == id);
        }

        
    }
}
