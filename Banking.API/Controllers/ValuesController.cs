using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections;
using Banking.Domain.ViewModel;
using Banking.BLL.Service;

namespace Banking.API.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly AuthService _authService;

        public ValuesController()
        {
            _authService = new AuthService();
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        public Object GetToken(UserViewModel userViewModel)
        {
            var token = _authService.GenerateToken(userViewModel);

            return new
            {
                data = token
            };
        }

        [HttpPost]
        public String GetName1()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable claims = identity.Claims;
                }
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public Object GetName2()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var login = claims.Where(p => p.Type == "login").FirstOrDefault()?.Value;
                return new
                {
                    data = login
                };

            }

            return null;
        }
    }
}
