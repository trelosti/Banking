using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Banking.API.Startup))]

namespace Banking.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://BankClient.Web", 
                        ValidAudience = "https://BankClient.Web",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ImX6m+1HiO0LZmeHTufvHTJAm2DH2MeHcBr12zh740sMQ+SyQ9wN7jz67bayV23T"))
                    }
                });
        }
    }
}
