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
    public class status_zakazisController : Controller
    {
        private readonly DataContext _context;

        public status_zakazisController(DataContext context)
        {
            _context = context;
        }

        // GET: status_zakazis
        public async Task<IActionResult> Index()
        {
              return View(await _context.status_zakazis.ToListAsync());
        }

        // GET: status_zakazis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.status_zakazis == null)
            {
                return NotFound();
            }

            var status_zakazis = await _context.status_zakazis
                .FirstOrDefaultAsync(m => m.id_status == id);
            if (status_zakazis == null)
            {
                return NotFound();
            }

            return View(status_zakazis);
        }

        // GET: status_zakazis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: status_zakazis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_status,status_name")] status_zakazis status_zakazis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status_zakazis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(status_zakazis);
        }

        // GET: status_zakazis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.status_zakazis == null)
            {
                return NotFound();
            }

            var status_zakazis = await _context.status_zakazis.FindAsync(id);
            if (status_zakazis == null)
            {
                return NotFound();
            }
            return View(status_zakazis);
        }

        // POST: status_zakazis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_status,status_name")] status_zakazis status_zakazis)
        {
            if (id != status_zakazis.id_status)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(status_zakazis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!status_zakazisExists(status_zakazis.id_status))
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
            return View(status_zakazis);
        }

        // GET: status_zakazis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.status_zakazis == null)
            {
                return NotFound();
            }

            var status_zakazis = await _context.status_zakazis
                .FirstOrDefaultAsync(m => m.id_status == id);
            if (status_zakazis == null)
            {
                return NotFound();
            }

            return View(status_zakazis);
        }

        // POST: status_zakazis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.status_zakazis == null)
            {
                return Problem("Entity set 'DataContext.status_zakazis'  is null.");
            }
            var status_zakazis = await _context.status_zakazis.FindAsync(id);
            if (status_zakazis != null)
            {
                _context.status_zakazis.Remove(status_zakazis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool status_zakazisExists(int id)
        {
          return _context.status_zakazis.Any(e => e.id_status == id);
        }
    }
}
