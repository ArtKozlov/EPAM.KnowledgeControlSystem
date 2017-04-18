using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Entities;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ISession _session;

        public UserRepository(ISession session)
        {
            _session = session;
        }

        public IEnumerable<User> GetAll()
        {        
                IEnumerable<User> result = _session.Query<User>().ToList();
                return result;
        }

        public User GetById(int key)
        {
                User user = _session.Query<User>().FirstOrDefault(i => i.Id == key);
                return user;
        }

        public User GetByEmail(string email)
        {
                return _session.Query<User>().FirstOrDefault(user => user.Email == email);
        }

        public void Create(User user)
        {
            if (ReferenceEquals(user, null))
                throw new ArgumentNullException();
            
                using (ITransaction transaction = _session.BeginTransaction())
                {
                
                    _session.Merge(user);
                    transaction.Commit();
                }
        }

        public void Delete(User user)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    User expectedUser = _session.Query<User>().FirstOrDefault(i => i.Id == user.Id);
                    if (!ReferenceEquals(expectedUser, null))
                    {
                        _session.Delete(expectedUser);
                        transaction.Commit();
                    }
                }
        }

        public void Update(User user)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    User entity = _session.Query<User>().FirstOrDefault(i => i.Id == user.Id);
                    if(!ReferenceEquals(entity, null))
                    { 
                        entity.Email = user.Email;
                        entity.Name = user.Name;
                        entity.Age = user.Age;
                        _session.Evict(entity);
                        _session.Update(entity);
                        transaction.Commit();
                    }
                }
        }

        public void UpdatePassword(User user)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    var entity = _session.Query<User>().FirstOrDefault(i => i.Id == user.Id);
                    if (!ReferenceEquals(entity, null))
                    {
                        entity.Password = user.Password;
                        _session.Save(entity);
                        transaction.Commit();
                    }
                }
        }

        public void Delete(int key)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    User user = _session.Query<User>().FirstOrDefault(i => i.Id == key);
                    if (!ReferenceEquals(user, null))
                    {
                        _session.Delete(user);
                        transaction.Commit();
                    }
                }
        }
    }
}
