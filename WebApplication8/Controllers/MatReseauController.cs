using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Services.BonDentreService;
using WebApplication8.Services.FournisseurService;
using WebApplication8.Services.MaterielService;

namespace WebApplication8.Controllers
{
    [Authorize]
    public class MatReseauController : Controller
    {
        private readonly Imateriel _materielService;
        private readonly IFournisseur _fournisseurService;
        private readonly IBonDentre _bonDentreservice;
        public MatReseauController(Imateriel materielService, IFournisseur fournisseurService, IBonDentre bonDentreservice)
        {
            _materielService = materielService;
            _materielService = materielService;
            _fournisseurService = fournisseurService;
            _bonDentreservice = bonDentreservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "ResponsableStock")]
        [HttpGet]
        public IActionResult Create()
        {
            var Fournisseurs = _fournisseurService.GetFournisseurs();
            var BonDentres = _bonDentreservice.GetBonDentres();
            ViewBag.BonDentres = new SelectList(BonDentres, "idBonDentre", "idBonDentre");
            ViewBag.Fournisseurs = new SelectList(Fournisseurs, "CodeFiscal", "NomFor");
            
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