using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Services;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AsteelDBcontext _context;
        private readonly UserManager<User> _userManager;
        public HomeController(ILogger<HomeController> logger, AsteelDBcontext context, UserManager<User> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {

                var materials = _context.Materiels.ToList();
                foreach (var material in materials)
{
                  if (material == null || material == null)
    {
        throw new Exception("Un élément de materials est null");
    }
}
                var suppliers = _context.Fournisseurs.ToList(); // Assuming you have a Fournisseurs table
                var affectations = _context.Affectations.ToList();
                var users =  _userManager.Users.ToList();

                var viewModel = new HomeViewModel
                {
                    Materials = materials,
                    Suppliers = suppliers,
                    Affectations=affectations,
                    Users=users
                };

                return View(viewModel);
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
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
