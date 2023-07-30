using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Banking.API.Providers
{
    public class MvcJwtAuthProvider : OAuthBearerAuthenticationProvider
    {
        public override Task RequestToken(OAuthRequestTokenContext context)
        {
            var token = context.Request.Cookies.SingleOrDefault(x => x.Key == "accessToken").Value;

            context.Token = token;
            return base.RequestToken(context);
        }
    }
}