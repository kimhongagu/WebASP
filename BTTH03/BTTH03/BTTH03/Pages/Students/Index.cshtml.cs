using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BTTH03.Models;
using System.Collections;

namespace BTTH03.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly BTTH03Context _context;

        public IndexModel(BTTH03Context context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync(string searchText, string orderBy)
        {
			if (_context.Student != null)
			{
				IQueryable<Student> studentQuery = _context.Student.Include(s => s.Class);

				// Xử lý tìm kiếm
				if (!string.IsNullOrEmpty(searchText))
				{
					studentQuery = studentQuery.Where(s => s.Code == searchText ||
														   s.Name.Contains(searchText) ||
														   (s.Class != null && s.Class.Title.Contains(searchText)));
				}

				// Xử lý sắp xếp
				if (!string.IsNullOrEmpty(orderBy) && orderBy == "Code")
				{
					studentQuery = studentQuery.OrderBy(s => s.Code);
				}

				Student = await studentQuery.ToListAsync();
			}
		}
    }
}
