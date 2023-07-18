using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace RealEstate.API.FitnessTests;

public class FakeAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public const string AuthScheme = "FakeAuth";

    public FakeAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
        UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authenticationTicket = new AuthenticationTicket(
            new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Email, "andrew@email.com"),
                new Claim(ClaimTypes.Name, "andrew@email.com"),
            }, AuthScheme)),
            new AuthenticationProperties(),
            AuthScheme);
        return Task.FromResult(AuthenticateResult.Success(authenticationTicket));
    }
}
