using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAbadLabCF.Data;
using SAbadLabCF.Models;

namespace SAbadLabCF.Controllers
{
    public class BurguersController : Controller
    {
        private readonly SAbadLabCFContext _context;

        public BurguersController(SAbadLabCFContext context)
        {
            _context = context;
        }

        // GET: Burguers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Burguers.ToListAsync());
        }

        // GET: Burguers/Details/5
        [HttpPost]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burguers = await _context.Burguers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (burguers == null)
            {
                return NotFound();
            }

            return View(burguers);
        }

        // GET: Burguers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Burguers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,WithCheese,Precio")] Burguers burguers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(burguers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(burguers);
        }

        // GET: Burguers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burguers = await _context.Burguers.FindAsync(id);
            if (burguers == null)
            {
                return NotFound();
            }
            return View(burguers);
        }

        // POST: Burguers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,WithCheese,Precio")] Burguers burguers)
        {
            if (id != burguers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burguers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurguersExists(burguers.Id))
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
            return View(burguers);
        }

        // GET: Burguers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burguers = await _context.Burguers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (burguers == null)
            {
                return NotFound();
            }

            return View(burguers);
        }

        // POST: Burguers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var burguers = await _context.Burguers.FindAsync(id);
            if (burguers != null)
            {
                _context.Burguers.Remove(burguers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurguersExists(int id)
        {
            return _context.Burguers.Any(e => e.Id == id);
        }
    }
}
