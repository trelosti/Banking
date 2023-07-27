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
            return _userRepository.GetAll().ToList();
        }

        public User GetUserById(long id)
        {
            return GetAllUsers().FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByLogin(string login)
        {
            return GetAllUsers().Where(x => x.Login.Contains(login)).FirstOrDefault();
        }
    }
}
