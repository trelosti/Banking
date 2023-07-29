using Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.BLL.Interface
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        User GetUserById(long id);

        User GetUserByLogin (string login);

        long GetUserIdByLogin(string login);

        User ValidateUser(string email, string password);
    }
}
