using Microsoft.AspNet.Identity;
using System;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using Base.Model.Model;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Base.App_Start
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

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

    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(new UserStore<AppUser>(context.Get<PracaDorywczaDbContext>()));
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            //manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<AppUser>
            //{
            //    MessageFormat = "Your security code is {0}"
            //});
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<AppUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
                manager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(dataProtectionProvider.Create("ASP.NET Identity"));

            return manager;
        }
    }
}