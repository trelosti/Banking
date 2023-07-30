﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Responses
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }

        public AuthResponse(string token)
        {
            AccessToken = token;
        }
    }
}
