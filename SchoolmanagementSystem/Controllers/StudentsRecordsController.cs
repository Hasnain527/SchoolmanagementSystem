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
    public class StudentsRecordsController : Controller
    {
        private readonly SchoolSystemContext _context;

        public StudentsRecordsController(SchoolSystemContext context)
        {
            _context = context;
        }

        // GET: StudentsRecords
        public async Task<IActionResult> Index()
        {
              return View(await _context.StudentsRecords.ToListAsync());
        }

        // GET: StudentsRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentsRecords == null)
            {
                return NotFound();
            }

            var studentsRecord = await _context.StudentsRecords
                .FirstOrDefaultAsync(m => m.StudentCnic == id);
            if (studentsRecord == null)
            {
                return NotFound();
            }

            return View(studentsRecord);
        }

        // GET: StudentsRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentsRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentCnic,StudentName,StudentDegree,StudentClass,StudentSection,StudentPhone,StudentAddress,StudentGroup")] StudentsRecord studentsRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentsRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentsRecord);
        }

        // GET: StudentsRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentsRecords == null)
            {
                return NotFound();
            }

            var studentsRecord = await _context.StudentsRecords.FindAsync(id);
            if (studentsRecord == null)
            {
                return NotFound();
            }
            return View(studentsRecord);
        }

        // POST: StudentsRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentCnic,StudentName,StudentDegree,StudentClass,StudentSection,StudentPhone,StudentAddress,StudentGroup")] StudentsRecord studentsRecord)
        {
            if (id != studentsRecord.StudentCnic)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentsRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsRecordExists(studentsRecord.StudentCnic))
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
            return View(studentsRecord);
        }

        // GET: StudentsRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentsRecords == null)
            {
                return NotFound();
            }

            var studentsRecord = await _context.StudentsRecords
                .FirstOrDefaultAsync(m => m.StudentCnic == id);
            if (studentsRecord == null)
            {
                return NotFound();
            }

            return View(studentsRecord);
        }

        // POST: StudentsRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentsRecords == null)
            {
                return Problem("Entity set 'SchoolSystemContext.StudentsRecords'  is null.");
            }
            var studentsRecord = await _context.StudentsRecords.FindAsync(id);
            if (studentsRecord != null)
            {
                _context.StudentsRecords.Remove(studentsRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsRecordExists(int id)
        {
          return _context.StudentsRecords.Any(e => e.StudentCnic == id);
        }
    }
}
