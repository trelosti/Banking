﻿using Banking.BLL.Interface;
using Banking.Domain.Responses;
using Banking.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
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

            var cookie = new HttpCookie("accessToken", token)
            {
                Expires = DateTime.Now.AddMinutes(30),
                HttpOnly = true
            };

            HttpContext.Current.Response.Cookies.Add(cookie);

            return new
            {
                data = token
            };
        }
    }
}
