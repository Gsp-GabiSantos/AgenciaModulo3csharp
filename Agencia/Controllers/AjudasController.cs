#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agencia.Models;

namespace Agencia.Controllers
{
    public class AjudasController : Controller
    {
        private readonly Context _context;

        public AjudasController(Context context)
        {
            _context = context;
        }

        // GET: Ajudas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ajuda.ToListAsync());
        }

        // GET: Ajudas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ajuda = await _context.Ajuda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ajuda == null)
            {
                return NotFound();
            }

            return View(ajuda);
        }

        // GET: Ajudas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ajudas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Telefone,Dúvida")] Ajuda ajuda)
        {
            
                _context.Add(ajuda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Ajudas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ajuda = await _context.Ajuda.FindAsync(id);
            if (ajuda == null)
            {
                return NotFound();
            }
            return View(ajuda);
        }

        // POST: Ajudas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Telefone,Dúvida")] Ajuda ajuda)
        {
          
                    _context.Update(ajuda);
                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Ajudas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ajuda = await _context.Ajuda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ajuda == null)
            {
                return NotFound();
            }

            return View(ajuda);
        }

        // POST: Ajudas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ajuda = await _context.Ajuda.FindAsync(id);
            _context.Ajuda.Remove(ajuda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AjudaExists(int id)
        {
            return _context.Ajuda.Any(e => e.Id == id);
        }
    }
}
