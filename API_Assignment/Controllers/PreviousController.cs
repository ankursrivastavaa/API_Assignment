using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API_Assignment.DataAccess;
using API_Assignment.Models;

namespace API_Assignment.Controllers
{
    public class PreviousController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PreviousController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Previous
        public async Task<IActionResult> Index()
        {
            return View(await _context.Previous.ToListAsync());
        }

        // GET: Previous/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var previous = await _context.Previous
                .FirstOrDefaultAsync(m => m.symbol == id);
            if (previous == null)
            {
                return NotFound();
            }

            return View(previous);
        }

        // GET: Previous/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Previous/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("symbol,datetime,open,high,low,close")] Previous previous)
        {
            if (ModelState.IsValid)
            {
                _context.Add(previous);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(previous);
        }

        // GET: Previous/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var previous = await _context.Previous.FindAsync(id);
            if (previous == null)
            {
                return NotFound();
            }
            return View(previous);
        }

        // POST: Previous/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("symbol,datetime,open,high,low,close")] Previous previous)
        {
            if (id != previous.symbol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(previous);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreviousExists(previous.symbol))
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
            return View(previous);
        }

        // GET: Previous/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var previous = await _context.Previous
                .FirstOrDefaultAsync(m => m.symbol == id);
            if (previous == null)
            {
                return NotFound();
            }

            return View(previous);
        }

        // POST: Previous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var previous = await _context.Previous.FindAsync(id);
            _context.Previous.Remove(previous);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreviousExists(string id)
        {
            return _context.Previous.Any(e => e.symbol == id);
        }
    }
}
