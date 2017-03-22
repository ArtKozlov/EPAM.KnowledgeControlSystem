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
            using (_session)
            {
                IEnumerable<User> result = _session.Query<User>().ToList();
                return result;
            }
        }

        public User GetById(int key)
        {
            using (_session)
            {
                User user = _session.Query<User>().FirstOrDefault(i => i.Id == key);
                return user;
            }
        }

        public User GetByEmail(string email)
        {
            using (_session)
            {
                return _session.Query<User>().FirstOrDefault(user => user.Email == email);
            }
        }

        public void Create(User user)
        {
            if (ReferenceEquals(user, null))
                throw new ArgumentNullException();

            using (_session)
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(user);
                    transaction.Commit();
                }
            }
        }

        public void Delete(User user)
        {
            using (_session)
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
        }

        public void Update(User user)
        {
            using (_session)
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    User entity = _session.Query<User>().FirstOrDefault(i => i.Id == user.Id);
                    if(!ReferenceEquals(entity, null))
                    { 
                        entity.Email = user.Email;
                        entity.Name = user.Name;
                        entity.Age = user.Age;
                        entity.Roles.Clear();
                        entity.Roles = user.Roles;
                        _session.Save(entity);
                        transaction.Commit();
                    }
                }
            }
        }

        public void UpdatePassword(User user)
        {
            using (_session)
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
        }

        public void Delete(int key)
        {
            using (_session)
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
}
