using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KP_APP.Models;

namespace KP_APP.Controllers
{
    public class tov_kategoriesController : Controller
    {
        private readonly DataContext _context;

        public tov_kategoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: tov_kategories
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.tov_kategories.Include(t => t.tov_kategories1);
            return View(await dataContext.ToListAsync());
        }

        // GET: tov_kategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tov_kategories == null)
            {
                return NotFound();
            }

            var tov_kategories = await _context.tov_kategories
                .Include(t => t.tov_kategories1)
                .FirstOrDefaultAsync(m => m.id_kategor == id);
            if (tov_kategories == null)
            {
                return NotFound();
            }

            return View(tov_kategories);
        }

        // GET: tov_kategories/Create
        public IActionResult Create()
        {
            ViewData["kat_glav_id"] = new SelectList(_context.tov_kategories, "id_kategor", "kategor_name");
            return View();
        }

        // POST: tov_kategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_kategor,kategor_name,kat_glav_id")] tov_kategories tov_kategories)
        {
            if (tov_kategories.kategor_name != null)
            {
                _context.Add(tov_kategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["kat_glav_id"] = new SelectList(_context.tov_kategories, "id_kategor", "kategor_name", tov_kategories.kat_glav_id);
            return View(tov_kategories);
        }

        // GET: tov_kategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tov_kategories == null)
            {
                return NotFound();
            }

            var tov_kategories = await _context.tov_kategories.FindAsync(id);
            if (tov_kategories == null)
            {
                return NotFound();
            }
            ViewData["kat_glav_id"] = new SelectList(_context.tov_kategories, "id_kategor", "kategor_name", tov_kategories.kat_glav_id);
            return View(tov_kategories);
        }

        // POST: tov_kategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_kategor,kategor_name,kat_glav_id")] tov_kategories tov_kategories)
        {
            if (id != tov_kategories.id_kategor)
            {
                return NotFound();
            }

            if (tov_kategories.kategor_name != null)
            {
                try
                {
                    _context.Update(tov_kategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tov_kategoriesExists(tov_kategories.id_kategor))
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
            ViewData["kat_glav_id"] = new SelectList(_context.tov_kategories, "id_kategor", "kategor_name", tov_kategories.kat_glav_id);
            return View(tov_kategories);
        }

        // GET: tov_kategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tov_kategories == null)
            {
                return NotFound();
            }

            var tov_kategories = await _context.tov_kategories
                .Include(t => t.tov_kategories1)
                .FirstOrDefaultAsync(m => m.id_kategor == id);
            if (tov_kategories == null)
            {
                return NotFound();
            }

            return View(tov_kategories);
        }

        // POST: tov_kategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tov_kategories == null)
            {
                return Problem("Entity set 'DataContext.tov_kategories'  is null.");
            }
            var tov_kategories = await _context.tov_kategories.FindAsync(id);
            if (tov_kategories != null)
            {
                _context.tov_kategories.Remove(tov_kategories);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tov_kategoriesExists(int id)
        {
          return _context.tov_kategories.Any(e => e.id_kategor == id);
        }
    }
}
