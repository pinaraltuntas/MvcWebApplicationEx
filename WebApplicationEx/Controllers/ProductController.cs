using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationEx.Data;
using WebApplicationEx.Models;
using WebApplicationEx.ViewModels;

namespace WebApplicationEx.Controllers
{
	[Route("Urunler/[action]/{id?}")]
	public class ProductController : Controller
	{
		private readonly ExAppDataContext _context;
		public ProductController(ExAppDataContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			List<Product> model = _context.Products.ToList();
			return View(model);
		}

		public IActionResult Detail(int id)
		{
			var model = _context.Products.Find(id);
			if (model == null)
			{
				return View("Error", new ErrorViewModel
				{
					ErrorTitle = "Hata",
					ErrorCode = 404,
					ErrorDesc = "Anasayfaya dönebilirsiniz."
				});
			}
			return View(model);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product model)
		{
			_context.Products.Add(model);
			_context.SaveChanges();
			return RedirectToAction("index");
		}

		public IActionResult Edit(int id)
		{
			var model = _context.Products.Find(id);
			if (model == null)
			{
				return View("Error", new ErrorViewModel
				{
					ErrorTitle = "Hata",
					ErrorCode = 404,
					ErrorDesc = ("NOT FOUND!")

				});
			}
			return View(model);
		}
		[HttpPost]
		public IActionResult Edit(Product model)
		{
			var oldProduct = _context.Products.Find(model.ProductId);
			if (oldProduct == null)
			{
				return View("Error", new ErrorViewModel
				{
					ErrorTitle = "Hata",
					ErrorCode = 404,
					ErrorDesc = ("NOT FOUND")

				});
			}

			oldProduct.Name = model.Name;
			oldProduct.Price = model.Price;
			oldProduct.Stock = model.Stock;
			_context.SaveChanges();
			return RedirectToAction("index");
		}

		public IActionResult Delete(int id)
		{
			var model = _context.Products.Find(id);
			if (model == null)
			{
				return View("Error", new ErrorViewModel
				{
					ErrorTitle = "Hata",
					ErrorCode = 404,
					ErrorDesc = ("Anasayfaya dönebilirsiniz.")

				});
			}
			return View(model);
		}

		[HttpPost]
		public IActionResult Delete(Product product)
		{
			var model = _context.Products.Find(product.ProductId);
			if (model == null)
			{
				return View("Error", new ErrorViewModel
				{
					ErrorTitle = "Hata",
					ErrorCode = 404,
					ErrorDesc = ("Anasayfaya dönebilirsiniz.")

				});
			}

			_context.Remove(model);
			_context.SaveChanges();
			return RedirectToAction("index");
		}
	}

}
