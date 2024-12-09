using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Areas.Admin.Models;
using WebApp1.Models;

namespace WebApp1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "1")]

    public class AdminMenusController : Controller
    {
        private readonly DataContext _context;

        public AdminMenusController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminMenus
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminMenus.ToListAsync());
        }

        // GET: Admin/AdminMenus/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminMenu = await _context.AdminMenus
                .FirstOrDefaultAsync(m => m.AdminMenuID == id);
            if (adminMenu == null)
            {
                return NotFound();
            }

            return View(adminMenu);
        }

        // GET: Admin/AdminMenus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminMenuID,ItemName,ItemLevel,ParentLevel,ItemOrder,IsActive,ItemTarget,AreaName,ControllerName,ActionName,Icon,IdName")] AdminMenu adminMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminMenu);
        }

        // GET: Admin/AdminMenus/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminMenu = await _context.AdminMenus.FindAsync(id);
            if (adminMenu == null)
            {
                return NotFound();
            }
            return View(adminMenu);
        }

        // POST: Admin/AdminMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("AdminMenuID,ItemName,ItemLevel,ParentLevel,ItemOrder,IsActive,ItemTarget,AreaName,ControllerName,ActionName,Icon,IdName")] AdminMenu adminMenu)
        {
            if (id != adminMenu.AdminMenuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminMenuExists(adminMenu.AdminMenuID))
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
            return View(adminMenu);
        }

        // GET: Admin/AdminMenus/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminMenu = await _context.AdminMenus
                .FirstOrDefaultAsync(m => m.AdminMenuID == id);
            if (adminMenu == null)
            {
                return NotFound();
            }

            return View(adminMenu);
        }

        // POST: Admin/AdminMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var adminMenu = await _context.AdminMenus.FindAsync(id);
            if (adminMenu != null)
            {
                _context.AdminMenus.Remove(adminMenu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminMenuExists(long id)
        {
            return _context.AdminMenus.Any(e => e.AdminMenuID == id);
        }
    }
}
