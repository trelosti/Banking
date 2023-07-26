using Banking.DAL.Interface;
using Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.DAL.Repository
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly ApplicationDbContext _db;

        public UserRepository()
        {
            _db = new ApplicationDbContext();
        }

        public async Task Create(User entity)
        {
            _db.Users.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<User> GetAll()
        {
            return _db.Users;
        }

        public async Task<User> Update(User entity)
        {
            User userToUpdate = _db.Users.FirstOrDefault(x => x.Id == entity.Id);
            if (userToUpdate != null)
            {
                userToUpdate.Login = entity.Login;
                userToUpdate.FirstName = entity.FirstName;
                userToUpdate.LastName = entity.LastName;
                userToUpdate.Email = entity.Email;
            }

            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
