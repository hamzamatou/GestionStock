using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Services.UserService;

namespace WebApplication8.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUser _userService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(IUser userService, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: UserController
        [HttpGet]
        public ActionResult Index()
        {
            var users = _userService.GetUsers();
            var userRolesViewModel = users.Select(
                user => new UserRolesViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Nom = user.nom,
                    Prenom = user.prenom,
                    tel = user.PhoneNumber,
                    Role = string.Join(", ", _userManager.GetRolesAsync(user).Result)
                }).ToList();

            return View(userRolesViewModel);
        }

        // GET: UserController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var userRolesViewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Nom = user.nom,
                Prenom = user.prenom,
                tel = user.PhoneNumber,
                Role = string.Join(", ", roles)
            };

            return View(userRolesViewModel);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return Redirect("/Identity/Account/Register");
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userViewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                Nom = user.nom,
                Prenom = user.prenom,
                UserName = user.UserName,
                tel = user.PhoneNumber,
                Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault() // Assuming single role
            };

            var roles = await _roleManager.Roles.Where(r => r.Name != "Admin")
         .Select(r => new SelectListItem
         {
             Value = r.Name,
             Text = r.Name
         }).ToListAsync();
            ViewBag.Roles = new SelectList(roles, "Value", "Text");

            return View(userViewModel);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserRolesViewModel userView)
        {
            try
            {
                var user = await _userService.GetUserAsync(userView.UserId);
                if (user != null)
                {
                    user.nom = userView.Nom;
                    user.prenom = userView.Prenom;
                    user.UserName = userView.UserName;
                    user.PhoneNumber = userView.tel;
                    //user.RoleId = userView.Role;
                    await _userService.UpdateUserAsync(user);
                    await _userService.UpdateUserRolesAsync(user, userView.Role);
                    return RedirectToAction("Index");
                }
                return View(userView);
            }
            catch
            {
                return View(userView);
            }
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}