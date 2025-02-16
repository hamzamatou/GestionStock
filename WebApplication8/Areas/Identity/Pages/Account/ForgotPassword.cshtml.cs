using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using WebApplication8.Models;
using WebApplication8.Services;

namespace WebApplication8.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IMail _mail;

        public ForgotPasswordModel(UserManager<User> userManager, IMail mail)
        {
            _userManager = userManager;
            _mail = mail;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Échec de la validation du formulaire.");
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                Console.WriteLine("Utilisateur non trouvé.");
                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            if (!(await _userManager.IsEmailConfirmedAsync(user)))
            {
                Console.WriteLine("L'utilisateur n'a pas confirmé son email.");
                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            try
            {
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                Console.WriteLine($"Token généré : {code}");

                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                Console.WriteLine($"Token encodé : {code}");

                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

                Console.WriteLine($"URL de réinitialisation : {callbackUrl}");

                _mail.Envoyer_Click(
                         $"Votre Compte a été bien crée pour notre système de gestion des équipement informatique tu peux consulter l' admininstareur sytème pour obtenir vos corrodonnées de connexion  ", "Gestionnaire Stock", Input.Email);

                Console.WriteLine("Email envoyé avec succès.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'envoi de l'email : {ex.Message}");
                ModelState.AddModelError(string.Empty, "Une erreur s'est produite lors de l'envoi de l'email.");
                return Page();
            }

            return RedirectToPage("./ForgotPasswordConfirmation");
        }
    }
}
