using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#pragma warning disable CS0105 // The using directive for 'Microsoft.AspNetCore.Mvc' appeared previously in this namespace
using Microsoft.AspNetCore.Mvc;
#pragma warning restore CS0105 // The using directive for 'Microsoft.AspNetCore.Mvc' appeared previously in this namespace
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CateringLarissa2.Data;
using CateringLarissa2.Models;

namespace CateringLarissa2.Controllers
{
    public class Dashboard : Controller
    {

        private readonly ApplicationDbContext _context;

        public Dashboard(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Review(String SearchString)
        {
            return View(await _context.Review.ToListAsync());
        }

        public IActionResult Account()
        {
            return View();
        }

        public async Task<IActionResult> Menu(String SearchString)
        {
            return View(await _context.Menu.ToListAsync());
        }

        public async Task<IActionResult> Pesanan(String SearchString)
        {
            return View(await _context.Pesan.OrderByDescending(j => j.orderedat).ToListAsync());
        }
        public async Task<IActionResult> Pesanan2(String SearchString)
        {
            return View(await _context.Pesan.OrderByDescending(j => j.orderedat).ToListAsync());
            
        }


    }
}
