using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectController : Controller
    {
        private readonly DataContext _context;

        public SubjectController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Subject
        public async Task<IActionResult> Index()
        {
            var subjects = _context.Subjects.ToList();
            return View(subjects);
        }

        // GET: Admin/Subject/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .Include(b => b.SubjectName)
                .FirstOrDefaultAsync(s => s.SubjectID== id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Admin/Subject/Create
        public IActionResult Create()
        {
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "SubjectID", "SubjectID");
            return View();
        }

        // POST: Admin/Subject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectID,SubjectName,Credits,Department,Semester,Alias")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "SubjectID", "AccountID", subject.SubjectID);
            return View(subject);
        }

        // GET: Admin/Subject/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "SubjectID", "SubjectID", subject.SubjectID);
            return View(subject);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectID,SubjectName,Credits,Department,Semester,Alias")] Subject subject)
        {
            if (id != subject.SubjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.SubjectID))
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
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "SubjectID", "SubjectID", subject.SubjectID);
            return View(subject);
        }

        //delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Subjects.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deletesubject = _context.Subjects.Find(id);
            if (deletesubject == null)
            {
                return NotFound();
            }
            _context.Subjects.Remove(deletesubject);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //end delete

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.SubjectID == id);
        }
    }
}
