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
    public class parametersController : Controller
    {
        private readonly DataContext _context;

        public parametersController(DataContext context)
        {
            _context = context;
        }

        // GET: parameters
        public async Task<IActionResult> Index()
        {
              return View(await _context.parameters.ToListAsync());
        }

        // GET: parameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.parameters == null)
            {
                return NotFound();
            }

            var parameters = await _context.parameters
                .FirstOrDefaultAsync(m => m.id_param == id);
            if (parameters == null)
            {
                return NotFound();
            }

            return View(parameters);
        }

        // GET: parameters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: parameters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_param,param_name")] parameters parameters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parameters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parameters);
        }

        // GET: parameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.parameters == null)
            {
                return NotFound();
            }

            var parameters = await _context.parameters.FindAsync(id);
            if (parameters == null)
            {
                return NotFound();
            }
            return View(parameters);
        }

        // POST: parameters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_param,param_name")] parameters parameters)
        {
            if (id != parameters.id_param)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parameters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!parametersExists(parameters.id_param))
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
            return View(parameters);
        }

        // GET: parameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.parameters == null)
            {
                return NotFound();
            }

            var parameters = await _context.parameters
                .FirstOrDefaultAsync(m => m.id_param == id);
            if (parameters == null)
            {
                return NotFound();
            }

            return View(parameters);
        }

        // POST: parameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.parameters == null)
            {
                return Problem("Entity set 'DataContext.parameters'  is null.");
            }
            var parameters = await _context.parameters.FindAsync(id);
            if (parameters != null)
            {
                _context.parameters.Remove(parameters);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool parametersExists(int id)
        {
          return _context.parameters.Any(e => e.id_param == id);
        }
    }
}
