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
    public class CadastroDestinosController : Controller
    {
        private readonly Context _context;

        public CadastroDestinosController(Context context)
        {
            _context = context;
        }

        // GET: CadastroDestinos
        public IActionResult Index()
        {
            return View(_context.CadastroDestino.ToList());
        }

        // GET: CadastroDestinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroDestino = await _context.CadastroDestino
                .FirstOrDefaultAsync(m => m.IdDestino == id);
            if (cadastroDestino == null)
            {
                return NotFound();
            }

            return View(cadastroDestino);
        }

        // GET: CadastroDestinos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroDestinos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDestino,Nome_Destino,Lugar,Valor")] CadastroDestino cadastroDestino)
        {
            
                _context.Add(cadastroDestino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: CadastroDestinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroDestino = await _context.CadastroDestino.FindAsync(id);
            if (cadastroDestino == null)
            {
                return NotFound();
            }
            return View(cadastroDestino);
        }

        // POST: CadastroDestinos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDestino,Nome_Destino,Lugar,Valor")] CadastroDestino cadastroDestino)
        {
          
                    _context.Update(cadastroDestino);
                    await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            
        }

        // GET: CadastroDestinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroDestino = await _context.CadastroDestino
                .FirstOrDefaultAsync(m => m.IdDestino == id);
            if (cadastroDestino == null)
            {
                return NotFound();
            }

            return View(cadastroDestino);
        }

        // POST: CadastroDestinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroDestino = await _context.CadastroDestino.FindAsync(id);
            _context.CadastroDestino.Remove(cadastroDestino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroDestinoExists(int id)
        {
            return _context.CadastroDestino.Any(e => e.IdDestino == id);
        }
    }
}
