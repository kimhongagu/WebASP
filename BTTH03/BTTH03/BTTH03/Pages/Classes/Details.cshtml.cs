using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BTTH03.Models;

namespace BTTH03.Pages.Classes
{
    public class DetailsModel : PageModel
    {
        private readonly BTTH03Context _context;

        public DetailsModel(BTTH03Context context)
        {
            _context = context;
        }

      public Class Class { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Class == null)
            {
                return NotFound();
            }

            var lop = await _context.Class.FirstOrDefaultAsync(m => m.ClassID == id);
            if (lop == null)
            {
                return NotFound();
            }
            else 
            {
                Class = lop;
            }
            return Page();
        }
    }
}
