using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;
using ORM;
using ORM.Entities;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TestingSystemContext _context;

        public UserRepository(TestingSystemContext uow)
        {
            _context = uow;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int key)
        {
            return _context.Users.Find(key);
        }
        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(user => user.Email == email);
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
        }

        public void Delete(User user)
        {
            var expectedUser = _context.Users.Single(u => u.Id == user.Id);
            if (!ReferenceEquals(expectedUser, null))
                _context.Users.Remove(expectedUser);
        }

        public void Update(User user)
        {
             var entity = _context.Users.Find(user.Id);
            entity.Email = user.Email;
            entity.Name = user.Name;
            entity.Age = user.Age;
            entity.Roles.Clear();
            entity.Roles = user.Roles;
            entity.TestResults.Clear();
            entity.TestResults = user.TestResults;
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void UpdatePassword(User user)
        {
            var entity = _context.Users.Find(user.Id);
            entity.Password = user.Password;
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(int key)
        {
            var expectedUser = _context.Users.Find(key);
            if(!ReferenceEquals(expectedUser, null))
                _context.Users.Remove(expectedUser);
        }
    }
}
