using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Entities;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private ISession _session;
        public RoleRepository(ISession session)
        {
            _session = session;
        }
        public IEnumerable<Role> GetAll()
        {
                IEnumerable<Role> result = _session.Query<Role>().ToList();
                return result;
        }
        public Role GetById(int key)
        {
                Role role = _session.Query<Role>().FirstOrDefault(i => i.Id == key);
                return role;
        }

        public void Create(Role role)
        {
            if (ReferenceEquals(role, null))
                throw new ArgumentNullException();
            
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(role);
                    transaction.Commit();
                }
        }

        public void Delete(Role role)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    Role expectedRole = _session.Query<Role>().FirstOrDefault(i => i.Id == role.Id);
                    if (!ReferenceEquals(expectedRole, null))
                    {
                        _session.Delete(expectedRole);
                        transaction.Commit();
                    }
                }
        }

        public void Update(Role role)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    Role entity = _session.Query<Role>().FirstOrDefault(i => i.Id == role.Id);
                    if (!ReferenceEquals(entity, null))
                    {
                        _session.SaveOrUpdate(entity);
                        transaction.Commit();
                    }
                }
        }

        public void Delete(int key)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    Role role = _session.Query<Role>().FirstOrDefault(i => i.Id == key);
                    if (!ReferenceEquals(role, null))
                    {
                        _session.Delete(role);
                        transaction.Commit();
                    }
                }
        }

        public Role GetByName(string name)
        {
                return _session.Query<Role>().FirstOrDefault(role => role.Name.ToLower() == name.ToLower());
        }
    }
}
