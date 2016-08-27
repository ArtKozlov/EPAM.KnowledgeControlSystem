using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;
using ORM;
using ORM.Entities;

namespace DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TestingSystemContext _context;
        public RoleRepository(TestingSystemContext uow)
        {
            _context = uow;
        }
        public IEnumerable<Role> GetAll()
        {
              return _context.Roles;
        }
        public Role GetById(int key)
        {
            return _context.Roles.Find(key);
        }

        public void Create(Role role)
        {
            _context.Roles.Add(role);
        }

        public void Delete(Role role)
        {
            var expectedRole = _context.Roles.Single(u => u.Id == role.Id);
            if (!ReferenceEquals(expectedRole, null))
                _context.Roles.Remove(expectedRole);
        }

        public void Update(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
        }

        public void Delete(int key)
        {
            var expectedRole = _context.Roles.Find(key);
            if (!ReferenceEquals(expectedRole, null))
                _context.Roles.Remove(expectedRole);
        }

        public Role GetByName(string name)
        {
            return _context.Roles.FirstOrDefault(role => role.Name == name);
        }
    }
}
