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
    public class sost_departmentsController : Controller
    {
        private readonly DataContext _context;

        public sost_departmentsController(DataContext context)
        {
            _context = context;
        }

        // GET: sost_departments
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.sost_departments.Include(s => s.departments).Include(s => s.positions);
            return View(await dataContext.ToListAsync());
        }

        // GET: sost_departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sost_departments == null)
            {
                return NotFound();
            }

            var sost_departments = await _context.sost_departments
                .Include(s => s.departments)
                .Include(s => s.positions)
                .FirstOrDefaultAsync(m => m.id_sost_dep == id);
            if (sost_departments == null)
            {
                return NotFound();
            }

            return View(sost_departments);
        }

        // GET: sost_departments/Create
        public IActionResult Create()
        {
            ViewData["id_dep"] = new SelectList(_context.departments, "id_dep", "dep_name");
            ViewData["id_pos"] = new SelectList(_context.positions, "id_pos", "pos_name");
            return View();
        }

        // POST: sost_departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_sost_dep,id_dep,id_pos")] sost_departments sost_departments)
        {
            if (sost_departments.id_dep != 0 && sost_departments.id_pos != 0)
            {
                _context.Add(sost_departments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_dep"] = new SelectList(_context.departments, "id_dep", "dep_name", sost_departments.id_dep);
            ViewData["id_pos"] = new SelectList(_context.positions, "id_pos", "pos_name", sost_departments.id_pos);
            return View(sost_departments);
        }

        // GET: sost_departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sost_departments == null)
            {
                return NotFound();
            }

            var sost_departments = await _context.sost_departments.FindAsync(id);
            if (sost_departments == null)
            {
                return NotFound();
            }
            ViewData["id_dep"] = new SelectList(_context.departments, "id_dep", "dep_name", sost_departments.id_dep);
            ViewData["id_pos"] = new SelectList(_context.positions, "id_pos", "pos_name", sost_departments.id_pos);
            return View(sost_departments);
        }

        // POST: sost_departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_sost_dep,id_dep,id_pos")] sost_departments sost_departments)
        {
            if (id != sost_departments.id_sost_dep)
            {
                return NotFound();
            }

            if (sost_departments.id_dep != 0 && sost_departments.id_pos != 0)
            {
                try
                {
                    _context.Update(sost_departments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sost_departmentsExists(sost_departments.id_sost_dep))
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
            ViewData["id_dep"] = new SelectList(_context.departments, "id_dep", "dep_name", sost_departments.id_dep);
            ViewData["id_pos"] = new SelectList(_context.positions, "id_pos", "pos_name", sost_departments.id_pos);
            return View(sost_departments);
        }

        // GET: sost_departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sost_departments == null)
            {
                return NotFound();
            }

            var sost_departments = await _context.sost_departments
                .Include(s => s.departments)
                .Include(s => s.positions)
                .FirstOrDefaultAsync(m => m.id_sost_dep == id);
            if (sost_departments == null)
            {
                return NotFound();
            }

            return View(sost_departments);
        }

        // POST: sost_departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sost_departments == null)
            {
                return Problem("Entity set 'DataContext.sost_departments'  is null.");
            }
            var sost_departments = await _context.sost_departments.FindAsync(id);
            if (sost_departments != null)
            {
                _context.sost_departments.Remove(sost_departments);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sost_departmentsExists(int id)
        {
          return _context.sost_departments.Any(e => e.id_sost_dep == id);
        }
    }
}
