using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CateringLarissa2.Data;
using CateringLarissa2.Models;
using CateringLarissa2.ViewModels;

namespace CateringLarissa2.Controllers
{
    public class MenusController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public MenusController(ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            WebHostEnvironment = webHostEnvironment;
        }

        // GET: Menus
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<IActionResult> Index()
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            var item = _context.Menu.ToList();
            return View(item);
        }

        // GET: Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu
                .FirstOrDefaultAsync(m => m.id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menus/Create
        public IActionResult Create2()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create3(MenuViewModel vm)
        {
            string stringFileName = UploadFile(vm);
            var menu = new Menu
            {
                title = vm.title,
                price = vm.price,
                description = vm.description,
                menuimage = stringFileName
            };
            _context.Menu.Add(menu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private string UploadFile(MenuViewModel vm)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string fileName = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (vm.menuimage != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath,
                    "Images");
                fileName = Guid.NewGuid().ToString() + "-" + vm.menuimage.FileName;
                string filepath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    vm.menuimage.CopyTo(fileStream);
                }
            }
#pragma warning disable CS8603 // Possible null reference return.
            return fileName;
#pragma warning restore CS8603 // Possible null reference return.
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,description,price")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        public async Task<IActionResult> Search(String SearchString)
        {
            if (SearchString != null)
            {
                return View("Index", await _context.Menu.Where(j => j.title.Contains(SearchString)).ToListAsync());
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,description,price,menuimage")] Menu menu)
        {
            if (id != menu.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.id))
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
            return View(menu);
        }

        // GET: Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu
                .FirstOrDefaultAsync(m => m.id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menu.FindAsync(id);
#pragma warning disable CS8604 // Possible null reference argument for parameter 'entity' in 'EntityEntry<Menu> DbSet<Menu>.Remove(Menu entity)'.
            _context.Menu.Remove(menu);
#pragma warning restore CS8604 // Possible null reference argument for parameter 'entity' in 'EntityEntry<Menu> DbSet<Menu>.Remove(Menu entity)'.
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menu.Any(e => e.id == id);
        }
    }
}
