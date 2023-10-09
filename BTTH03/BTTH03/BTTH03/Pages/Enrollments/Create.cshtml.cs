using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BTTH03.Models;

namespace BTTH03.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly BTTH03Context _context;

        public CreateModel(BTTH03Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseID"] = new SelectList(_context.Course, "CourseID", "CourseID");
        ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "StudentID", "StudentID");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Enrollment == null || Enrollment == null)
            {
                return Page();
            }

            _context.Enrollment.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
