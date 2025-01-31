using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Services;

namespace WebApplication8.Controllers
{
    [Authorize(Roles = "Admin,AgentIT")]
    public class EmployeController : Controller
    {
        private readonly AsteelDBcontext _context;
        public EmployeController(AsteelDBcontext context) {
            _context = context;
        }
        // GET: EmployeController
        public ActionResult Index()
        {
            _context.Employes.ToList();
            return View(_context.Employes.ToList());
        }

        // GET: EmployeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Employes.Find(id));
        }

        // GET: EmployeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
