using Microsoft.AspNet.Identity;
using System;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

public class EmailService : IIdentityMessageService
{
    public Task SendAsync(IdentityMessage message)
    {
        return configSendGridasyncAsync(message);
    }

    private async Task configSendGridasyncAsync(IdentityMessage message)
    {
        MailMessage mailMsg = new MailMessage();

        // To
        mailMsg.To.Add(new MailAddress(message.Destination));

        // From
        mailMsg.From = new MailAddress("konta@pracadorywczatest.aspnet.pl", "Praca dorywcza - nie odpisuj");

        // Subject and multipart/alternative Body
        mailMsg.Subject = message.Subject;
        mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, MediaTypeNames.Text.Plain));
        mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, MediaTypeNames.Text.Html));

        // Init SmtpClient and send
        SmtpClient smtpClient = new SmtpClient("poczta.dcsweb.pl", Convert.ToInt32(587));
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("konta@pracadorywczatest.aspnet.pl", "");
        smtpClient.Credentials = credentials;
        //smtpClient.Send(mailMsg);
        await smtpClient.SendMailAsync(mailMsg);
    }
}