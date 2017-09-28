using Base.Model.Model;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;

namespace Base.Providers
{
    public class SimpleRefreshTokenProvider : AuthenticationTokenProvider
    {
        public override async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            context.Ticket.Properties.AllowRefresh = true;

            var refreshTokenId = Guid.NewGuid().ToString("n");

            using (PracaDorywczaDbContext db = new PracaDorywczaDbContext())
            {
                var token = new RefreshToken()
                {
                    Id = GetHash(refreshTokenId),
                    UserName = context.Ticket.Identity.Name,
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(10)
                };


                context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
                context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;

                token.ProtectedTicket = context.SerializeTicket();

                db.RefreshToken.Add(token);

                var result = await db.SaveChangesAsync() > 0;

                if (result)
                    context.SetToken(refreshTokenId);
            }
        }

        public override async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            string hashedTokenId = GetHash(context.Token);

            using (PracaDorywczaDbContext db = new PracaDorywczaDbContext())
            {
                var refreshToken = await db.RefreshToken.FindAsync(hashedTokenId);

                if (refreshToken != null)
                {
                    context.DeserializeTicket(refreshToken.ProtectedTicket);
                    db.RefreshToken.Remove(refreshToken);
                    var result = await db.SaveChangesAsync() > 0;
                }
            }
        }

        private static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }
    }
}