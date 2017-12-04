using Base.App_Start;
using Base.Model.Model;
using Base.Model.Model.User;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Base.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            var uid = context.Parameters.Where(f => f.Key == "otpkey").Select(f => f.Value).SingleOrDefault();
            if(uid != null)
            {
                context.OwinContext.Set<string>("otpkey", uid[0]);
            }
            await base.ValidateClientAuthentication(context);
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (AppUserManager userManager = context.OwinContext.GetUserManager<AppUserManager>())
            {
                AppUser user = await userManager.FindAsync(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "Nazwa użytkownika lub hasło jest nie prawidłowe.");
                    return;
                }
                //if (!user.EmailConfirmed)
                //{
                //    context.SetError("invalid_grant", "Potwierdź swój email");
                //    return;
                //}
                //string otp = context.OwinContext.Get<string>("otpkey");
                //bool otpcheck = await userManager.VerifyTwoFactorTokenAsync(user.Id, "Email Code", otp);
                //if (!otpcheck)
                //{
                //    context.SetError("invalid_grant", "Hasło jednorazowe jest nie poprawne");
                //    return;
                //}
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, context.ClientId));
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            var property = new AuthenticationProperties(new Dictionary<string, string>
            {
                {"UserName", context.UserName }
            });
            var ticket = new AuthenticationTicket(identity, property);

            context.Validated(ticket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }

    }
}