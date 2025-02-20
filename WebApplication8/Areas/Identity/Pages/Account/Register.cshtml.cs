﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using WebApplication8.Models;
using WebApplication8.Services;

namespace WebApplication8.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    //[Authorize(Roles ="Admin")]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IMail _mail;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AsteelDBcontext _context;  // Ajout du contexte de la base de données pour vérifier les employés



        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IMail mail,
            RoleManager<IdentityRole> roleManager,
            AsteelDBcontext context)  // Ajout du contexte de la base de données pour vérifier les employés
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mail = mail;
            _roleManager = roleManager;
            _context = context;  // Initialisation du contexte
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Nom")]
            public string Nom { get; set; }

            [Required]
            [Display(Name = "Prenom")]
            public string Prenom { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Role")]
            public string SelectedRole { get; set; }

            public IEnumerable<SelectListItem> Roles { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            Input = new InputModel
            {
                Roles = _roleManager.Roles
                    .Where(r => r.Name != "Admin") 
                    .Select(r => new SelectListItem
                    {
                        Value = r.Name,
                        Text = r.Name
                    }).ToList()
            };
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                // Vérifier si l'utilisateur est un employé
                var employe = _context.Employes.FirstOrDefault(e => e.Nom == Input.Nom && e.Prenom == Input.Prenom && e.Email == Input.Email);
               /* if (employe == null)
                {
                    ModelState.AddModelError(string.Empty, "Aucun employé correspondant trouvé.");
                    Input.Roles = _roleManager.Roles
                        .Where(r => r.Name != "Admin")  // Exclusion du rôle "Admin"
                        .Select(r => new SelectListItem
                        {
                            Value = r.Name,
                            Text = r.Name
                        }).ToList();
                    return Page();
                }
                */
                var user = new User
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    nom = Input.Nom,
                    prenom = Input.Prenom,
                   // PhoneNumber=employe.tel
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {

                    // Assigner le rôle sélectionné à l'utilisateur
                    await _userManager.AddToRoleAsync(user, Input.SelectedRole);
                    ModelState.AddModelError(string.Empty, "l'utilisateur est bien crée");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    _mail.Envoyer_Click(
                        $"Votre Compte a été bien crée pour notre système de gestion des équipement informatique tu peux consulter l' admininstareur sytème pour obtenir vos corrodonnées de connexion  ","Gestionnaire Stock",Input.Email );

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Si la validation échoue, réaffiche le formulaire avec les erreurs
            Input.Roles = _roleManager.Roles
               // .Where(r => r.Name != "Admin")  // Exclusion du rôle "Admin"
                .Select(r => new SelectListItem
                {
                    Value = r.NormalizedName,
                    Text = r.Name
                }).ToList();
            return Page();
        }
    }
}
