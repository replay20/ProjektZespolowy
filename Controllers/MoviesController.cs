using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPracownik.Models;
using WebApplication1.Models.Data;

namespace WebApplication1.Controllers
{
    public class PracowniksController : Controller
    {
        private readonly PracownicyContext _context;

        public PracowniksController(PracownicyContext context)
        {
            _context = context;
        }

        // GET: Pracowniks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pracownik.ToListAsync());
        }

        // GET: Pracowniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Pracownik = await _context.Pracownik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Pracownik == null)
            {
                return NotFound();
            }

            return View(Pracownik);
        }

        // GET: Pracowniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pracowniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,login,haslo")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pracownik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pracownik);
        }

        // GET: Pracowniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Pracownik = await _context.Pracownik.FindAsync(id);
            if (Pracownik == null)
            {
                return NotFound();
            }
            return View(Pracownik);
        }

        // POST: Pracowniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,login,haslo")] Pracownik Pracownik)
        {
            if (id != Pracownik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Pracownik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracownikExists(Pracownik.Id))
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
            return View(Pracownik);
        }

        // GET: Pracowniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownik = await _context.Pracownik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pracownik == null)
            {
                return NotFound();
            }

            return View(pracownik);
        }

        // POST: Pracowniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pracownik = await _context.Pracownik.FindAsync(id);
            _context.Pracownik.Remove(pracownik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PracownikExists(int id)
        {
            return _context.Pracownik.Any(e => e.Id == id);
        }
    }
}
