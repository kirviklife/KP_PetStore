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
    public class positionsController : Controller
    {
        private readonly DataContext _context;

        public positionsController(DataContext context)
        {
            _context = context;
        }

        // GET: positions
        public async Task<IActionResult> Index()
        {
              return View(await _context.positions.ToListAsync());
        }

        // GET: positions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.positions == null)
            {
                return NotFound();
            }

            var positions = await _context.positions
                .FirstOrDefaultAsync(m => m.id_pos == id);
            if (positions == null)
            {
                return NotFound();
            }

            return View(positions);
        }

        // GET: positions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: positions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_pos,pos_name")] positions positions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(positions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(positions);
        }

        // GET: positions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.positions == null)
            {
                return NotFound();
            }

            var positions = await _context.positions.FindAsync(id);
            if (positions == null)
            {
                return NotFound();
            }
            return View(positions);
        }

        // POST: positions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_pos,pos_name")] positions positions)
        {
            if (id != positions.id_pos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(positions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!positionsExists(positions.id_pos))
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
            return View(positions);
        }

        // GET: positions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.positions == null)
            {
                return NotFound();
            }

            var positions = await _context.positions
                .FirstOrDefaultAsync(m => m.id_pos == id);
            if (positions == null)
            {
                return NotFound();
            }

            return View(positions);
        }

        // POST: positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.positions == null)
            {
                return Problem("Entity set 'DataContext.positions'  is null.");
            }
            var positions = await _context.positions.FindAsync(id);
            if (positions != null)
            {
                _context.positions.Remove(positions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool positionsExists(int id)
        {
          return _context.positions.Any(e => e.id_pos == id);
        }
    }
}
