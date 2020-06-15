using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationEx.Data;

namespace WebApplicationEx.Controllers
{
    public class HomeController : Controller
    {
		private readonly ExAppDataContext context;
		public HomeController(ExAppDataContext _context)
		{
			//ExAppDataContext context = new ExAppDataContext(); şeklinde yapmak yerine IOC den instance yapılır
			context = _context;
	
		}
		public IActionResult Index() => View();
    }
}