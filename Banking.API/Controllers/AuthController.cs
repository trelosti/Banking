using Banking.BLL.Interface;
using Banking.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Banking.API.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public Object Login(UserViewModel userViewModel)
        {
            var token = _authService.GenerateToken(userViewModel);

            return new
            {
                data = token
            };
        }
    }
}
