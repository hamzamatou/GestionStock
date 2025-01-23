using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Services.FournisseurService;

public class FournisseurController : Controller
{
    private readonly IFournisseur _fournisseurService;

    public FournisseurController(IFournisseur fournisseurService)
    {
        _fournisseurService = fournisseurService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var fournisseurs = _fournisseurService.GetFournisseurs();
        return View(fournisseurs);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
     public IActionResult Create(Fournisseur fournisseur)
     {
         if (ModelState.IsValid)
         {
            _fournisseurService.Create(fournisseur);
             return RedirectToAction(nameof(Index));
         }
         return View(fournisseur);
     }

     [HttpPost]
    public IActionResult Delete(string id)
    {
        _fournisseurService.DeleteFournisseur(id);
        return RedirectToAction(nameof(Index));
    }


    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var fournisseur = await _fournisseurService.GetFournisseurAsync(id);
        return View(fournisseur);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Fournisseur fournisseur)
    {
        if (ModelState.IsValid)
        {
            await _fournisseurService.UpdateFournisseurAsync(fournisseur);
            return RedirectToAction(nameof(Index));
        }
        return View(fournisseur);
    }
    [HttpGet]
    public IActionResult Details (string id)
    {
        return View(_fournisseurService.GetFournisseur(id));
    }
}
