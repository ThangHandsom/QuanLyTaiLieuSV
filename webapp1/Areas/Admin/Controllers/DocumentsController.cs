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
    public class DocumentsController : Controller
    {
        private readonly DataContext _context;

        public DocumentsController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Documents
        public async Task<IActionResult> Index(int id)
        {
            var subject = await _context.Subjects
                .FirstOrDefaultAsync(b => b.SubjectID == id);

            if (subject == null)
            {
                return NotFound();
            }

            var documents = await _context.Documents
                .Where(bc => bc.SubjectID == id)
                .ToListAsync();

            ViewBag.SubjectID = subject.SubjectID;
            ViewBag.SubjectName = subject.SubjectName;

            return View(documents);
        }


        // GET: Admin/Documents/Create
        public IActionResult Create(int subjectId)
        {
            var subject = _context.Subjects.FirstOrDefault(s => s.SubjectID == subjectId);

            if (subject == null)
            {
                return NotFound();
            }

            ViewBag.SubjectID = subject.SubjectID;
            ViewBag.SubjectName = subject.SubjectName; 

            return View();
        }


        // POST: Admin/Documents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentID,DocumentName,Description,FilePath,SubjectID")] Document document)
        {
            if (ModelState.IsValid)
            {
                _context.Add(document);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Documents", new { id = document.SubjectID });
            }

            ViewData["SubjectID"] = new SelectList(_context.Subjects, "SubjectID", "SubjectName", document.SubjectID);
            return View(document);
        }



        // GET: Admin/Documents/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(s => s.SubjectID == document.SubjectID);

            if (subject != null)
            {
                ViewBag.SubjectID = subject.SubjectID;
                ViewBag.SubjectName = subject.SubjectName;
            }

            return View(document);
        }

        // POST: Admin/Documents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentID,DocumentName,Description,FilePath,SubjectID")] Document document)
        {
            if (id != document.DocumentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.DocumentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index", "Documents", new { id = document.SubjectID });
            }

            ViewBag.SubjectName = _context.Subjects
                .Where(s => s.SubjectID == document.SubjectID)
                .Select(s => s.SubjectName)
                .FirstOrDefault();

            return View(document);
        }



        // GET: Admin/Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(d => d.Subject)
                .FirstOrDefaultAsync(m => m.DocumentID == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Admin/Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document != null)
            {
                _context.Documents.Remove(document);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Documents", new { id = document.SubjectID });
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.DocumentID == id);
        }
    }
}
