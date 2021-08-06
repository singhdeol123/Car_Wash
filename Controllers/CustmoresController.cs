using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Car_Wash.Data;
using Car_Wash.Models;
using Microsoft.AspNetCore.Authorization;

namespace Car_Wash.Controllers
{
    [Authorize]
    public class CustmoresController : Controller
    {
        private readonly Car_WashContext _context;

        public CustmoresController(Car_WashContext context)
        {
            _context = context;
        }

        // GET: Custmores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Custmore.ToListAsync());
        }

        // GET: Custmores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custmore = await _context.Custmore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (custmore == null)
            {
                return NotFound();
            }

            return View(custmore);
        }

        // GET: Custmores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Custmores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone")] Custmore custmore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(custmore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(custmore);
        }

        // GET: Custmores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custmore = await _context.Custmore.FindAsync(id);
            if (custmore == null)
            {
                return NotFound();
            }
            return View(custmore);
        }

        // POST: Custmores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone")] Custmore custmore)
        {
            if (id != custmore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(custmore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustmoreExists(custmore.Id))
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
            return View(custmore);
        }

        // GET: Custmores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custmore = await _context.Custmore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (custmore == null)
            {
                return NotFound();
            }

            return View(custmore);
        }

        // POST: Custmores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var custmore = await _context.Custmore.FindAsync(id);
            _context.Custmore.Remove(custmore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustmoreExists(int id)
        {
            return _context.Custmore.Any(e => e.Id == id);
        }
    }
}
