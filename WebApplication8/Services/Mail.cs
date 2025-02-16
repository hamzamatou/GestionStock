using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace WebApplication8.Services
{
    public class Mail : IMail
    {
        public void Envoyer_Click(string htmlMailBody, string comment, string mailto)
        {
            try
            {
                // Chemin correct vers l'image
                var linkedResource = new LinkedResource(@"c:\\Users\\hamza\\OneDrive\\Bureau\\@startuml\\image.jpeg", MediaTypeNames.Image.Jpeg);
                linkedResource.ContentId = Guid.NewGuid().ToString();

                var htmlBody = $"{htmlMailBody}<br><br>{comment}<br><hr><img src=\"cid:{linkedResource.ContentId}\"/>";
                var alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                alternateView.LinkedResources.Add(linkedResource);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("hamzamaatougui06@gmail.com"),
                    Subject = "FLASHTRACK - Report",
                    IsBodyHtml = true
                };

                mailMessage.To.Add(mailto);
                mailMessage.AlternateViews.Add(alternateView);

                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new NetworkCredential("hamzamaatougui06@gmail.com", "zcwy cznd geqy jdky");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'envoi de l'email : {ex.Message}");
            }
        }
    }
}
