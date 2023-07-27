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

        public User ValidateUser(string login, string password)
        {
            var user = GetAllUsers().FirstOrDefault(x => x.Login == login);
            if (user == null)
            {
                return null;
            }

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
            return isPasswordValid ? user : null;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll().ToList();
        }

        public User GetUserById(long id)
        {
            return GetAllUsers().FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByLogin(string login)
        {
            return GetAllUsers().FirstOrDefault(x => x.Login == login);
        }
    }
}
