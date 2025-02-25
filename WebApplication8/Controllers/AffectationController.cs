using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Services.AffectationService;
using WebApplication8.Services.MaterielService;
using WebApplication8.Services.EmployeService;

namespace WebApplication8.Controllers
{
    [Authorize(Roles = "Admin,AgentIT")]
    public class AffectationController : Controller
    {
        private readonly IAffectation _affectationService;
        private readonly UserManager<User> _userManager;
        private readonly Imateriel _materielService;
        private readonly IEmploye _employeService; 

        public AffectationController(IAffectation affectationService, UserManager<User> userManager, Imateriel materielService, IEmploye employeService)
        {
            _affectationService = affectationService;
            _userManager = userManager;
            _materielService = materielService;
            _employeService = employeService; 
        }

        
        public ActionResult Index()
        {
            return View(_affectationService.GetAffectations());
        }

        
        public ActionResult Create()
        {
            ViewBag.AvailableMaterials = _materielService.GetMaterielsDisponibles().Select(m => new SelectListItem
            {
                Value = m.IdMat,
                Text = m.Description
            });
            return View();
        }

       
        [HttpPost]
        public async Task<ActionResult> Create(Affectation affectation)
        {
            if (ModelState.IsValid)
            {
               
                var employe =  _employeService.GetEmployeById(affectation.IdEmpAffected);
                if (employe != null) 
                {
                    var user = await _userManager.GetUserAsync(User);
           
                        affectation.IdUserAffecting = user.Id;
                        _affectationService.Create(affectation);

                        return RedirectToAction("Decharge", new { idMat = affectation.IdMat, dateAffectation = affectation.DateAffectation.ToString("yyyy-MM-dd") });
          
                }
                else
                {
                    
                    ModelState.AddModelError("", "L'employé n'existe pas.");
                }
            }

            return View(affectation);
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

        public IActionResult Search(string searchTerm)
        {
            var affectations = _affectationService.SearchAffectations(searchTerm);
            if (!affectations.Any())
            {
                ViewData["NoResults"] = "Aucun résultat trouvé.";
            }
            return View("Index", affectations);
        }
    }
}
