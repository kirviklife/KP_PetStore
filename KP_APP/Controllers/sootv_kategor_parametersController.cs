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
    public class sootv_kategor_parametersController : Controller
    {
        private readonly DataContext _context;

        public sootv_kategor_parametersController(DataContext context)
        {
            _context = context;
        }

        // GET: sootv_kategor_parameters
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.sootv_kategor_parameters.Include(s => s.parameters).Include(s => s.tov_kategories);
            return View(await dataContext.ToListAsync());
        }

        // GET: sootv_kategor_parameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sootv_kategor_parameters == null)
            {
                return NotFound();
            }

            var sootv_kategor_parameters = await _context.sootv_kategor_parameters
                .Include(s => s.parameters)
                .Include(s => s.tov_kategories)
                .FirstOrDefaultAsync(m => m.id_sootv_par == id);
            if (sootv_kategor_parameters == null)
            {
                return NotFound();
            }

            return View(sootv_kategor_parameters);
        }

        // GET: sootv_kategor_parameters/Create
        public IActionResult Create()
        {
            ViewData["id_param"] = new SelectList(_context.parameters, "id_param", "param_name");
            ViewData["id_kategor"] = new SelectList(_context.tov_kategories, "id_kategor", "kategor_name");
            return View();
        }

        // POST: sootv_kategor_parameters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_sootv_par,id_kategor,id_param")] sootv_kategor_parameters sootv_kategor_parameters)
        {
            if (sootv_kategor_parameters.id_kategor != null && sootv_kategor_parameters.id_param != null)
            {
                _context.Add(sootv_kategor_parameters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_param"] = new SelectList(_context.parameters, "id_param", "param_name", sootv_kategor_parameters.id_param);
            ViewData["id_kategor"] = new SelectList(_context.tov_kategories, "id_kategor", "kategor_name", sootv_kategor_parameters.id_kategor);
            return View(sootv_kategor_parameters);
        }

        // GET: sootv_kategor_parameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sootv_kategor_parameters == null)
            {
                return NotFound();
            }

            var sootv_kategor_parameters = await _context.sootv_kategor_parameters.FindAsync(id);
            if (sootv_kategor_parameters == null)
            {
                return NotFound();
            }
            ViewData["id_param"] = new SelectList(_context.parameters, "id_param", "param_name", sootv_kategor_parameters.id_param);
            ViewData["id_kategor"] = new SelectList(_context.tov_kategories, "id_kategor", "kategor_name", sootv_kategor_parameters.id_kategor);
            return View(sootv_kategor_parameters);
        }

        // POST: sootv_kategor_parameters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_sootv_par,id_kategor,id_param")] sootv_kategor_parameters sootv_kategor_parameters)
        {
            if (id != sootv_kategor_parameters.id_sootv_par)
            {
                return NotFound();
            }

            if (sootv_kategor_parameters.id_kategor != null && sootv_kategor_parameters.id_param != null)
            {
                try
                {
                    _context.Update(sootv_kategor_parameters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sootv_kategor_parametersExists(sootv_kategor_parameters.id_sootv_par))
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
            ViewData["id_param"] = new SelectList(_context.parameters, "id_param", "param_name", sootv_kategor_parameters.id_param);
            ViewData["id_kategor"] = new SelectList(_context.tov_kategories, "id_kategor", "kategor_name", sootv_kategor_parameters.id_kategor);
            return View(sootv_kategor_parameters);
        }

        // GET: sootv_kategor_parameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sootv_kategor_parameters == null)
            {
                return NotFound();
            }

            var sootv_kategor_parameters = await _context.sootv_kategor_parameters
                .Include(s => s.parameters)
                .Include(s => s.tov_kategories)
                .FirstOrDefaultAsync(m => m.id_sootv_par == id);
            if (sootv_kategor_parameters == null)
            {
                return NotFound();
            }

            return View(sootv_kategor_parameters);
        }

        // POST: sootv_kategor_parameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sootv_kategor_parameters == null)
            {
                return Problem("Entity set 'DataContext.sootv_kategor_parameters'  is null.");
            }
            var sootv_kategor_parameters = await _context.sootv_kategor_parameters.FindAsync(id);
            if (sootv_kategor_parameters != null)
            {
                _context.sootv_kategor_parameters.Remove(sootv_kategor_parameters);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sootv_kategor_parametersExists(int id)
        {
          return _context.sootv_kategor_parameters.Any(e => e.id_sootv_par == id);
        }
    }
}
