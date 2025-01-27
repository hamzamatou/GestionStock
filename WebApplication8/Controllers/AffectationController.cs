using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Services.AffectationService;

namespace WebApplication8.Controllers
{
    [Authorize(Roles = "Admin,AgentIT")]

    public class AffectationController : Controller
    {
        private readonly IAffectation _affectationService;
        private readonly UserManager <User> _userManager;
        public AffectationController(IAffectation affectationService , UserManager<User> userManager)
        {
            _affectationService = affectationService;
            _userManager = userManager;
        }
        // GET: HomeController1
        public ActionResult Index()
        {
            return View(_affectationService.GetAffectations());
        }

        // GET: HomeController1/Details/5
        public async Task<ActionResult>  Details(string idMat, DateTime dateAffectation)
        {
            
            return View( await _affectationService.GetAffectationAsync(idMat, dateAffectation));
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        public async Task<ActionResult> Create(Affectation affectation)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    affectation.IdUserAffecting = user.Id;
                    _affectationService.Create(affectation);
                    return RedirectToAction("Decharge",new { idMat=affectation.IdMat,dateAffectation=affectation.DateAffectation.ToString("yyyy-MM-dd") });
                }
                else
                {
                    // Gérer le cas où l'utilisateur n'est pas trouvé
                    ModelState.AddModelError("", "Utilisateur non trouvé.");
                }
            }
            return View(affectation);
        }

        // GET: HomeController1/Edit/5
        public async Task<ActionResult> Edit(string idMat , DateTime dateAffectation)
        {
            return View(await _affectationService.GetAffectationAsync(idMat, dateAffectation));
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Affectation affectation)
        {
            if (ModelState.IsValid)
            {
                var updatedAffectation = await _affectationService.UpdateAffectationAsync(affectation);
                if (updatedAffectation != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Affectation non trouvée.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Modèle non valide.");
            }
            return View(affectation);
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        public async Task<IActionResult> Decharge(string idMat, DateTime dateAffectation)
        {
            var affectation = await _affectationService.GetAffectationAsync(idMat, dateAffectation);
            if (affectation == null)
            {
                return NotFound();
            }
            
            return View(affectation);
        }

        // POST: HomeController1/Delete/5
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
