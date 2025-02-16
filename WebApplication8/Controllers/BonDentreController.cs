using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Services.BonDentreService;
using WebApplication8.Services.MaterielService;

[Authorize]
public class BonDentreController : Controller
{
    private readonly IBonDentre _bonDentreService;
    private readonly Imateriel _materielservice;
    public BonDentreController(IBonDentre bonDentreService, Imateriel materielservice)
    {
        _bonDentreService = bonDentreService;
        _materielservice= materielservice;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var bonDentres = _bonDentreService.GetBonDentres();
        return View(bonDentres);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [Authorize(Roles = "ResponsableStock")]
    [HttpPost]
    public IActionResult Create(BonDentre bonDentre)
    {
        if (ModelState.IsValid)
        {
            _bonDentreService.Create(bonDentre);
            return RedirectToAction(nameof(Index));
        }
        return View(bonDentre);
    }

    [HttpPost]
    public IActionResult Delete(string id)
    {
        _bonDentreService.DeleteBonDentre(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var bonDentre = await _bonDentreService.GetBonDentreAsync(id);
        return View(bonDentre);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(BonDentre bonDentre)
    {
        if (ModelState.IsValid)
        {
            await _bonDentreService.UpdateBonDentreAsync(bonDentre);
            return RedirectToAction(nameof(Index));
        }
        return View(bonDentre);
    }

    [HttpGet]
    public IActionResult Details(string id)
    {
        ViewBag.Materiels= _materielservice.GetMaterielsByBonDentre(id);
        return View(_bonDentreService.GetBonDentre(id));
    }
}
