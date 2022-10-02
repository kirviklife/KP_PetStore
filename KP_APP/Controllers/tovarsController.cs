using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KP_APP.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;

namespace KP_APP.Controllers
{
    public class tovarsController : Controller
    {
        private readonly DataContext _context;

        public tovarsController(DataContext context)
        {
            _context = context;
        }

        // GET: tovars
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.tovars.Include(t => t.tov_kategories);
            return View(await dataContext.ToListAsync());
        }

        // GET: tovars/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.tovars == null)
            {
                return NotFound();
            }

            var tovars = await _context.tovars
                .Include(t => t.tov_kategories)
                .FirstOrDefaultAsync(m => m.articule == id);
            if (tovars == null)
            {
                return NotFound();
            }

            return View(tovars);
        }

        // GET: tovars/Create
        public IActionResult Create()
        {
            ViewData["id_kategor"] = new SelectList(_context.tov_kategories, "id_kategor", "kategor_name");
            return View();
        }

        // POST: tovars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(tovars tovars)
        {
            if (tovars.articule != null && tovars.tovar_name != null && tovars.tovar_opis != null && tovars.cena != null)
            {
                _context.Add(tovars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_kategor"] = new SelectList(_context.tov_kategories, "id_kategor", "kategor_name", tovars.id_kategor);
            return View(tovars);
        }

        // GET: tovars/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.tovars == null)
            {
                return NotFound();
            }

            var tovars = await _context.tovars.FindAsync(id);
            if (tovars == null)
            {
                return NotFound();
            }
            ViewData["id_kategor"] = new SelectList(_context.tov_kategories, "id_kategor", "kategor_name", tovars.id_kategor);
            return View(tovars);
        }

        // POST: tovars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("articule,id_kategor,tovar_name,tovar_opis,cena")] tovars tovars)
        {
            if (id != tovars.articule)
            {
                return NotFound();
            }
            if (tovars.articule != null && tovars.tovar_name != null && tovars.tovar_opis != null && tovars.cena != null)
            {
                try
                {
                    _context.Update(tovars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tovarsExists(tovars.articule))
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
            ViewData["id_kategor"] = new SelectList(_context.tov_kategories, "id_kategor", "kategor_name", tovars.id_kategor);
            return View(tovars);
        }

        // GET: tovars/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.tovars == null)
            {
                return NotFound();
            }

            var tovars = await _context.tovars
                .Include(t => t.tov_kategories)
                .FirstOrDefaultAsync(m => m.articule == id);
            if (tovars == null)
            {
                return NotFound();
            }

            return View(tovars);
        }

        // POST: tovars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.tovars == null)
            {
                return Problem("Entity set 'DataContext.tovars'  is null.");
            }
            var tovars = await _context.tovars.FindAsync(id);
            if (tovars != null)
            {
                _context.tovars.Remove(tovars);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tovarsExists(string id)
        {
          return _context.tovars.Any(e => e.articule == id);
        }
    }
}
