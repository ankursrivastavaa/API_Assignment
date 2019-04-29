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
    public class DividendsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DividendsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dividends
        public async Task<IActionResult> Index()
        {
            return View(await _context.Divident.ToListAsync());
        }

        // GET: Dividends/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dividends = await _context.Divident
                .FirstOrDefaultAsync(m => m.Exe_date == id);
            if (dividends == null)
            {
                return NotFound();
            }

            return View(dividends);
        }

        // GET: Dividends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dividends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Exe_date,Pay_date,Rec_date,Amount,Dividends_type")] Dividends dividends)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dividends);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dividends);
        }

        // GET: Dividends/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dividends = await _context.Divident.FindAsync(id);
            if (dividends == null)
            {
                return NotFound();
            }
            return View(dividends);
        }

        // POST: Dividends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("Exe_date,Pay_date,Rec_date,Amount,Dividends_type")] Dividends dividends)
        {
            if (id != dividends.Exe_date)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dividends);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DividendsExists(dividends.Exe_date))
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
            return View(dividends);
        }

        // GET: Dividends/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dividends = await _context.Divident
                .FirstOrDefaultAsync(m => m.Exe_date == id);
            if (dividends == null)
            {
                return NotFound();
            }

            return View(dividends);
        }

        // POST: Dividends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var dividends = await _context.Divident.FindAsync(id);
            _context.Divident.Remove(dividends);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DividendsExists(DateTime id)
        {
            return _context.Divident.Any(e => e.Exe_date == id);
        }
    }
}
