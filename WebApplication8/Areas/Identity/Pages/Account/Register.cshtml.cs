using System;
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
using WebApplication8.Services.EmployeService;

namespace WebApplication8.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IMail _mail;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmploye _employeService; // Injection du service Employe

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IMail mail,
            RoleManager<IdentityRole> roleManager,
            IEmploye employeService)  // Ajout du service employé
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mail = mail;
            _roleManager = roleManager;
            _employeService = employeService;  // Initialisation du service
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
            [StringLength(100, ErrorMessage = "Le {0} doit contenir au moins {2} et au maximum {1} caractères.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mot de passe")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmer le mot de passe")]
            [Compare("Password", ErrorMessage = "Le mot de passe et la confirmation ne correspondent pas.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Rôle")]
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
                // Vérifier si l'utilisateur est un employé enregistré
               /* var employe = _employeService.GetEmployee(Input.Nom, Input.Prenom, Input.Email);

                if (employe == null)
                {
                    ModelState.AddModelError(string.Empty, "L'employé n'existe pas dans le système.");
                    return Page();
                }*/

                var user = new User
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    nom = Input.Nom,
                    prenom = Input.Prenom,
                    //PhoneNumber = employe.tel  Assigner le téléphone de l'employé si existant
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Input.SelectedRole);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));


                    try
                    {
                 
                        _mail.Envoyer_Click(
                            $"Votre compte a été créé avec succès pour notre système de gestion des équipements informatiques. Voici vos informations de connexion :<br><br>" +
                            $"<strong>Login :</strong> {Input.Email}<br>" +
                            $"<strong>Mot de passe :</strong> {Input.Password}<br><br>",
                            "Création de compte - Gestionnaire Stock",
                            Input.Email
                        );

                        _logger.LogInformation("E-mail de confirmation envoyé à {Email}", Input.Email);
                        ModelState.AddModelError(string.Empty, "L'utilisateur a été créé avec succès. Un e-mail de confirmation a été envoyé.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Erreur lors de l'envoi de l'e-mail de confirmation à {Email}", Input.Email);
                        ModelState.AddModelError(string.Empty, "Une erreur s'est produite lors de l'envoi de l'e-mail de confirmation.");
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return LocalRedirect("~/");
         
            // Si la validation échoue, réafficher le formulaire avec les erreurs
            Input.Roles = _roleManager.Roles
                .Select(r => new SelectListItem
                {
                    Value = r.NormalizedName,
                    Text = r.Name
                }).ToList();

            return Page();
        }
    }
}
