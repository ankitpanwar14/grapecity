using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BlogApp.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BlogApp.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly postDBContext _context;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            postDBContext context)
            : base(options, logger, encoder, clock)
        {
            _context = context;

        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Need authorization header in the request");

            try
            {
                User user =  await Task.Run(() => getUser());
                if (user == null)
                    AuthenticateResult.Fail("invalid credentials");
                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, user.userName) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Wrong user details");
            }
            
            return AuthenticateResult.Fail("");
        }

        private User getUser()
        {
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            String[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
            String username = credentials[0];
            String password = credentials[1];

            User user = _context.Users.Where(u => u.userName == username && u.pwd == password).FirstOrDefault();

            return user;
        }
    }
}
