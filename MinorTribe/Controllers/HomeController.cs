using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinorTribe.Models;

namespace MinorTribe.Controllers
{
    public class HomeController : Controller
    {
        private readonly MinorTribeContext _context;

        // Constructor (It is called when this file is loaded)
        public HomeController(MinorTribeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Getting our products (list of products)
            List<Product> model = _context.Products.Where(x => x.IsFeatured == true).ToList();

            // Passing the list of products to the view
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
