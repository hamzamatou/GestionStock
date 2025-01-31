using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using YamlDotNet.Core.Events;

namespace WebApplication8.Services
{
    public class Mail:IMail
    {
        public void Envoyer_Click(string htmlMailBody, string comment,string mailto)
        {
            var linkedResource = new LinkedResource(@"temp\printscreen.jpg", MediaTypeNames.Image.Jpeg);
            var htmlBody = "" + htmlMailBody + "<br><br>" + comment + "<br><hr>" + $"<img src=\"cid:{linkedResource.ContentId}\"/>";
            var alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(linkedResource);
            var mailMessage = new MailMessage
            {
                From = new MailAddress("Flash.Track@asteelflash.com"),
                To = { mailto },
                Subject = "FLASHTRACK - Report",
                AlternateViews = { alternateView }
            };
            var smtpClient = new SmtpClient("10.200.0.209");
            smtpClient.Send(mailMessage);
        }
    }
}
