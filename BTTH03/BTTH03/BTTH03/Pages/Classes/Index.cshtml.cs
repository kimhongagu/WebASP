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
    public class IndexModel : PageModel
    {
        private readonly BTTH03Context _context;

        public IndexModel(BTTH03Context context)
        {
            _context = context;
        }

        public IList<Class> Class { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Class != null)
            {
                Class = await _context.Class.ToListAsync();
            }
        }
    }
}
