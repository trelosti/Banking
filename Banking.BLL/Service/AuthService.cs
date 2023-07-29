using Banking.BLL.Interface;
using Banking.Domain.Entity;
using Banking.Domain.Enum;
using Banking.Domain.ViewModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Banking.BLL.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;

        public AuthService(IUserService userService)
        {
            _userService = userService;
        }

        public string GenerateToken(UserViewModel userViewModel)
        {
            if (_userService.ValidateUser(userViewModel.Login, userViewModel.Password) != null)
            {
                string key = "ImX6m+1HiO0LZmeHTufvHTJAm2DH2MeHcBr12zh740sMQ+SyQ9wN7jz67bayV23T";
                var issuer = "https://BankClient.Web";

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


                var permClaims = new List<Claim>();

                var userRoles = getUserRoles(userViewModel.Login);

                permClaims.Add(new Claim("iat", ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds().ToString()));
                permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                foreach (RoleName role in userRoles)
                {
                    permClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                }

                var header = new JwtHeader(signingCredentials: credentials);

                var payload = new JwtPayload(issuer,
                                issuer,
                                permClaims,
                                null,
                                expires: DateTime.Now.AddMinutes(30),
                                issuedAt: DateTime.Now);

                var token = new JwtSecurityToken(header, payload);
                var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                return jwt_token;
            }
            else
            {
                return "User not found";
            }
        }

        private List<RoleName> getUserRoles(string login)
        {
            var user = _userService.GetUserByLogin(login);

            var roleIds = user.UserRoles.Select(ur => ur.RoleId);

            return roleIds.Select(r => (RoleName)r).ToList();
        }
    }
}
