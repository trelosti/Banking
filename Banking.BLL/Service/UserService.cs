using Banking.BLL.Interface;
using Banking.DAL.Interface;
using Banking.DAL.Repository;
using Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public User ValidateUser(string email, string password)
        {
            var userList = GetAllUsers();
            var user = userList.FirstOrDefault(x => x.Email == email && x.Password == password);
            return user;
        }

        public List<User> GetAllUsers()
        {
            var users =  _userRepository.GetAll().ToList();
            return users;
        }

        public User GetUserById(long id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
