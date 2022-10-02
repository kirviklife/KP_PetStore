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
    public class accountsController : Controller
    {
        private readonly DataContext _context;

        public accountsController(DataContext context)
        {
            _context = context;
        }

        // GET: accounts
        public async Task<IActionResult> Index()
        {
              return View(await _context.accounts.ToListAsync());
        }

        // GET: accounts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.accounts == null)
            {
                return NotFound();
            }

            var accounts = await _context.accounts
                .FirstOrDefaultAsync(m => m.login == id);
            if (accounts == null)
            {
                return NotFound();
            }

            return View(accounts);
        }

        // GET: accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("login,fam,im,otch,passwordhash,numphone,email,is_sotr")] accounts accounts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accounts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accounts);
        }

        // GET: accounts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.accounts == null)
            {
                return NotFound();
            }

            var accounts = await _context.accounts.FindAsync(id);
            if (accounts == null)
            {
                return NotFound();
            }
            return View(accounts);
        }

        // POST: accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("login,fam,im,otch,passwordhash,numphone,email,is_sotr")] accounts accounts)
        {
            if (id != accounts.login)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accounts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!accountsExists(accounts.login))
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
            return View(accounts);
        }

        // GET: accounts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.accounts == null)
            {
                return NotFound();
            }

            var accounts = await _context.accounts
                .FirstOrDefaultAsync(m => m.login == id);
            if (accounts == null)
            {
                return NotFound();
            }

            return View(accounts);
        }

        // POST: accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.accounts == null)
            {
                return Problem("Entity set 'DataContext.accounts'  is null.");
            }
            var accounts = await _context.accounts.FindAsync(id);
            if (accounts != null)
            {
                _context.accounts.Remove(accounts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool accountsExists(string id)
        {
          return _context.accounts.Any(e => e.login == id);
        }
    }
}
