using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CateringLarissa2.Data;
using CateringLarissa2.Models;

namespace CateringLarissa2.Controllers
{
    public class PesansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PesansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pesans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pesan.ToListAsync());
        }

        // GET: Pesans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesan = await _context.Pesan
                .FirstOrDefaultAsync(m => m.id == id);
            if (pesan == null)
            {
                return NotFound();
            }

            return View(pesan);
        }

        // GET: Pesans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pesans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,menuname,alamat,nomorhp,price,username,status,arrivedat")] Pesan pesan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pesan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pesan);
        }

        // GET: Pesans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesan = await _context.Pesan.FindAsync(id);
            if (pesan == null)
            {
                return NotFound();
            }
            return View(pesan);
        }

        // POST: Pesans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,menuname,alamat,nomorhp,price,username,status")] Pesan pesan)
        {
            if (id != pesan.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pesan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PesanExists(pesan.id))
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
            return View(pesan);
        }

        // GET: Pesans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesan = await _context.Pesan
                .FirstOrDefaultAsync(m => m.id == id);
            if (pesan == null)
            {
                return NotFound();
            }

            return View(pesan);
        }
        public async Task<IActionResult> Delete2(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesan = await _context.Pesan
                .FirstOrDefaultAsync(m => m.id == id);
            if (pesan == null)
            {
                return NotFound();
            }

            return View(pesan);
        }

        // POST: Pesans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pesan = await _context.Pesan.FindAsync(id);
            _context.Pesan.Remove(pesan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PesanExists(int id)
        {
            return _context.Pesan.Any(e => e.id == id);
        }
    }
}
