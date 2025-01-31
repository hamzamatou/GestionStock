using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Services.MaterielService;

namespace WebApplication8.Controllers
{
    [Authorize]
    public class MatReseauController : Controller
    {
        private readonly Imateriel _materielService;
        public MatReseauController(Imateriel materielService)
        {
            _materielService = materielService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MatReseau mat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _materielService.Create(mat);
                    return RedirectToAction();
                }
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View(mat);
        }
        public IActionResult Details(string id)
        {
            var materiel = _materielService.GetMateriel(id);
            return View(materiel);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var Materiel = await _materielService.GetMaterielAsync(id);
            return View(Materiel);
        }
    }
}