using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolmanagementSystem.data;

namespace SchoolmanagementSystem.Controllers
{
    public class TeachersRecordsController : Controller
    {
        private readonly SchoolSystemContext _context;

        public TeachersRecordsController(SchoolSystemContext context)
        {
            _context = context;
        }

        // GET: TeachersRecords
        public async Task<IActionResult> Index()
        {
              return View(await _context.TeachersRecords.ToListAsync());
        }

        // GET: TeachersRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TeachersRecords == null)
            {
                return NotFound();
            }

            var teachersRecord = await _context.TeachersRecords
                .FirstOrDefaultAsync(m => m.TeacherCnic == id);
            if (teachersRecord == null)
            {
                return NotFound();
            }

            return View(teachersRecord);
        }

        // GET: TeachersRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeachersRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherCnic,TeacherName,TeacherQualification,TeacherClass,TeacherSubject,TeacherPhone,TeacherAddress,TeacherExperience")] TeachersRecord teachersRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teachersRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teachersRecord);
        }

        // GET: TeachersRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TeachersRecords == null)
            {
                return NotFound();
            }

            var teachersRecord = await _context.TeachersRecords.FindAsync(id);
            if (teachersRecord == null)
            {
                return NotFound();
            }
            return View(teachersRecord);
        }

        // POST: TeachersRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherCnic,TeacherName,TeacherQualification,TeacherClass,TeacherSubject,TeacherPhone,TeacherAddress,TeacherExperience")] TeachersRecord teachersRecord)
        {
            if (id != teachersRecord.TeacherCnic)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teachersRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachersRecordExists(teachersRecord.TeacherCnic))
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
            return View(teachersRecord);
        }

        // GET: TeachersRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TeachersRecords == null)
            {
                return NotFound();
            }

            var teachersRecord = await _context.TeachersRecords
                .FirstOrDefaultAsync(m => m.TeacherCnic == id);
            if (teachersRecord == null)
            {
                return NotFound();
            }

            return View(teachersRecord);
        }

        // POST: TeachersRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TeachersRecords == null)
            {
                return Problem("Entity set 'SchoolSystemContext.TeachersRecords'  is null.");
            }
            var teachersRecord = await _context.TeachersRecords.FindAsync(id);
            if (teachersRecord != null)
            {
                _context.TeachersRecords.Remove(teachersRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeachersRecordExists(int id)
        {
          return _context.TeachersRecords.Any(e => e.TeacherCnic == id);
        }
    }
}
