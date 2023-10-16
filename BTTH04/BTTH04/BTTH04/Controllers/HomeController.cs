using BTTH04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using X.PagedList;

namespace BTTH04.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;

        public HomeController(ILogger<HomeController> logger, MyDbContext context)
		{
			_logger = logger;
            _context = context;
        }

		public async Task<IActionResult> Index(int? page)
		{
            // Số lượng mục trên mỗi trang
            int pageSize = 4;

            // Trang hiện tại (nếu không được đặt, mặc định là 1)
            int pageNumber = (page ?? 1);

			var categories = await _context.Categories.ToListAsync();
			ViewData["Categories"] = categories;

			var products = await _context.Products.ToPagedListAsync(pageNumber, pageSize);
            return View(products);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}