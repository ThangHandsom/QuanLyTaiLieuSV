using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;
using WebApp1.Utilities;
using X.PagedList.Extensions;

namespace WebApp1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "1")]

    public class AccountsController : Controller
    {
        private readonly DataContext _context;

        public AccountsController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Accounts
        public async Task<IActionResult> Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            var dataContext = _context.Accounts.Include(a => a.Role).ToPagedList((int)page, pageSize);
            return View(dataContext);
        }

        // GET: Admin/Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }
    
        // GET: Admin/Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleID", account.RoleID);
            return View(account);
        }

        // POST: Admin/Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Admin/Accounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountID,UserName,Password,FullName,Class,StudentCode,Phone,Email,Gender,Birth,RoleID,LastLogin,IsActive,Image")] Account account)
        {
            if (id != account.AccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingAccount = await _context.Accounts.FindAsync(id);
                    if (existingAccount != null)
                    {
                        existingAccount.UserName = account.UserName;
                        existingAccount.FullName = account.FullName;
                        existingAccount.Class = account.Class;
                        existingAccount.StudentCode = account.StudentCode;
                        existingAccount.Phone = account.Phone;
                        existingAccount.Email = account.Email;
                        existingAccount.Gender = account.Gender;
                        existingAccount.Birth = account.Birth;
                        existingAccount.RoleID = account.RoleID;
                        existingAccount.LastLogin = account.LastLogin;
                        existingAccount.IsActive = account.IsActive;
                        existingAccount.Image = account.Image;

                        if (!string.IsNullOrEmpty(account.Password))
                        {
                            existingAccount.Password = HashMD5.GetHash(account.Password); 
                        }

                        _context.Update(existingAccount);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountID))
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
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleID", account.RoleID);
            return View(account);
        }


        // GET: Admin/Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Admin/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountID == id);
        }
    }
}
