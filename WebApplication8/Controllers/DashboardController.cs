using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication8.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashboard()
        {
            return View();
        }

        [Authorize(Roles = "AgentIt")]
        public IActionResult AgentItDashboard()
        {
            return View();
        }

        [Authorize(Roles = "ResponsableStock")]
        public IActionResult ResponsableStockDashboard()
        {
            return View();
        }
    }
}