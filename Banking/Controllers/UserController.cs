using Banking.BLL.Interface;
using Banking.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Banking.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public IHttpActionResult GetFirstUser(int id)
        {
            var user = _userService.GetAllUsers().FirstOrDefault(x => x.Id == id);
            return Ok(user);
        }
    }
}
