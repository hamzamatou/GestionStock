using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using YamlDotNet.Core.Events;

namespace WebApplication8.Services
{
    public class Mail : IMail
    {
        public void Envoyer_Click(string htmlMailBody, string comment, string mailto)
        {
            // Utilisez le chemin correct pour votre image
            var linkedResource = new LinkedResource(@"c:\Users\hamza\OneDrive\Bureau\@startuml\@startuml.png", MediaTypeNames.Image.Jpeg);
            var htmlBody = "" + htmlMailBody + " < br><br>" + comment + "<br><hr>" + $"<img src=\"cid:{linkedResource.ContentId}\"/>";
            var alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(linkedResource);

            // Utilisez votre adresse email personnelle comme expéditeur
            var mailMessage = new MailMessage
            {
                From = new MailAddress("hamza@gamil.com"),
                To = { mailto },
                Subject = "FLASHTRACK - Report",
                AlternateViews = { alternateView }
            };

            // Utilisez l'adresse et le port SMTP appropriés pour votre serveur local
            var smtpClient = new SmtpClient("localhost", 25);
            smtpClient.Send(mailMessage);
        }
    }
}
