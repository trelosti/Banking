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
        private readonly UserService _userService;

        public AuthService()
        {
            _userService = new UserService();
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
                permClaims.Add(new Claim("login", userViewModel.Login));

                var userRoles = getUserRoles(userViewModel.Login);

                foreach(RoleName role in userRoles)
                {
                    permClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                }

                var token = new JwtSecurityToken(issuer,
                                issuer,
                                permClaims,
                                expires: DateTime.Now.AddMinutes(5),
                                signingCredentials: credentials);
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
