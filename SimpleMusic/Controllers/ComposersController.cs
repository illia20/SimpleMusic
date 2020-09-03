using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleMusic.Models;

namespace SimpleMusic.Controllers
{
    public class ComposersController : Controller
    {
        private readonly MusicDbContext _context;

        public ComposersController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: Composers
        public async Task<IActionResult> Index()
        {
            var musicDbContext = _context.Composers.Include(c => c.Country);
            return View(await musicDbContext.ToListAsync());
        }

        // GET: Composers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var composer = await _context.Composers
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (composer == null)
            {
                return NotFound();
            }

            return View(composer);
        }

        // GET: Composers/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: Composers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Photo,Bio,CountryId")] Composer composer)
        {
            if ((!ComposerExists(composer)) && ModelState.IsValid)
            {
                _context.Add(composer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", composer.CountryId);
            return View(composer);
        }

        // GET: Composers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var composer = await _context.Composers.FindAsync(id);
            if (composer == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", composer.CountryId);
            return View(composer);
        }

        // POST: Composers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Photo,Bio,CountryId")] Composer composer)
        {
            if (id != composer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(composer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComposerExists(composer.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", composer.CountryId);
            return View(composer);
        }

        // GET: Composers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var composer = await _context.Composers
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (composer == null)
            {
                return NotFound();
            }

            return View(composer);
        }

        // POST: Composers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var composer = await _context.Composers.FindAsync(id);
            _context.Composers.Remove(composer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComposerExists(int id)
        {
            return _context.Composers.Any(e => e.Id == id);
        }
        private bool ComposerExists(Composer comp)
        {
            return _context.Composers.Any(e => e.Name == comp.Name);
        }
    }
}
