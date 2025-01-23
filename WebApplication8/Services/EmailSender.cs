using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;
    public AuthMessageSenderOptions Options { get; }

    public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor, ILogger<EmailSender> logger)
    {
        Options = optionsAccessor.Value;
        _logger = logger;
    }

    public Task SendEmailAsync(string email, string subject, string message)
    {
        return Execute(Options.SendGridKey, subject, message, email);
    }

    public Task Execute(string apiKey, string subject, string message, string email)
    {
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("hamzamaatougui06@gmail.com", "Your Name"),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message
        };
        msg.AddTo(new EmailAddress(email));

        // Désactiver le suivi des clics
        msg.SetClickTracking(false, false);

        return client.SendEmailAsync(msg);
    }
}
