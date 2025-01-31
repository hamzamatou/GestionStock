using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Services.MaterielService;
[Authorize]
public class MaterielController : Controller
{
    private readonly Imateriel _materielService;

    public MaterielController(Imateriel materielService)
    {
        _materielService = materielService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var materiels = _materielService.GetMateriels();
        return View(materiels);
    }
    [Authorize(Roles = "ResponsableStock")]
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Materiel materiel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _materielService.Create(materiel);
                return RedirectToAction();
            }
        }
        catch (ApplicationException ex)
        {
            ViewBag.ErrorMessage = ex.Message;
        }
        return View(materiel);
    }


    [HttpPost]
    public IActionResult Delete(string id)
    {
        _materielService.DeleteMat(id);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit( string id )
    {
       var Materiel=await _materielService.GetMaterielAsync(id);
        if (Materiel is MatReseau)
        {
            return RedirectToAction("Edit", "MatReseau", new { id = Materiel.IdMat });
        }
        return View(Materiel);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Materiel materiel)
    {
        if (ModelState.IsValid)
        {
            await _materielService.UpdateMaterielAsync(materiel);
            return RedirectToAction(nameof(Index));
        }
        return View(materiel);
    }
    [HttpGet]
    public IActionResult Details(string id)
    {
        var materiel = _materielService.GetMateriel(id);
        if(materiel is MatReseau)
        {
            return RedirectToAction("Details", "MatReseau", new { id = materiel.IdMat });
        }
        return View(materiel);
    }
    [HttpGet]
    public IActionResult GetMaterielsByType(string type)
    {
       var materiels= _materielService.GetMaterielsByType(type);

        return View("Index", materiels);
    }
    public IActionResult GetMaterielsDisponibles()
    {
        var materiels = _materielService.GetMaterielsDisponibles();
        return View("Index", materiels);
    }
    public IActionResult Search(string searchTerm)
    {
        var materiels = _materielService.SearchByMaterial(searchTerm);
        return View("Index", materiels);
    }

}
