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
    public class ComprasController : Controller
    {
        private readonly Context _context;

        public ComprasController(Context context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            var context = _context.Comprar.Include(c => c.CadastroDestino);
            return View(await context.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprar = await _context.Comprar
                .Include(c => c.CadastroDestino)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (comprar == null)
            {
                return NotFound();
            }

            return View(comprar);
        }

        // GET: Compras/Create
        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewBag.Destinos = new SelectList(_context.CadastroDestino, "IdDestino", "Lugar");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create(Comprar comprar)
        {

            _context.Comprar.Add(comprar);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprar = await _context.Comprar.FindAsync(id);
            if (comprar == null)
            {
                return NotFound();
            }
            ViewData["IdDestino"] = new SelectList(_context.CadastroDestino, "IdDestino", "Lugar", comprar.IdDestino);
            return View(comprar);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompra,Seu_Nome,Telefone,Email,CPF,Pagamento,IdDestino")] Comprar comprar)
        {
            
           
                
                
                    _context.Update(comprar);
                    await _context.SaveChangesAsync();
                
                
                return RedirectToAction(nameof(Index));
            
            ViewData["IdDestino"] = new SelectList(_context.CadastroDestino, "IdDestino", "Lugar", comprar.IdDestino);
            return View(comprar);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprar = await _context.Comprar
                .Include(c => c.CadastroDestino)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (comprar == null)
            {
                return NotFound();
            }

            return View(comprar);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comprar = await _context.Comprar.FindAsync(id);
            _context.Comprar.Remove(comprar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComprarExists(int id)
        {
            return _context.Comprar.Any(e => e.IdCompra == id);
        }
    }
}
