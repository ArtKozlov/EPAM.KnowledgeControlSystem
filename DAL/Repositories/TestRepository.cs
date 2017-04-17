using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Entities;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Repositories
{
    public class TestRepository: ITestRepository
    {
        private readonly ISession _session;

        public TestRepository(ISession session)
        {
            _session = session;
        }

        public IEnumerable<Test> GetAll()
        {
                IEnumerable<Test> result = _session.Query<Test>().ToList();
                return result;
        }

        public Test GetById(int key)
        {
                Test test = _session.Query<Test>().FirstOrDefault(i => i.Id == key);
                return test;
        }

        public void Create(Test test)
        {
            for (int i = 0; i < test.Questions.Count; i++)
            {
                test.Questions[i].Test = test;
                test.Answers[i].Test = test;
            }
            if (ReferenceEquals(test, null))
                throw new ArgumentNullException();
            
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(test);
                    transaction.Commit();
                }
        }

        public void Delete(Test test)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    Test expectedTest = _session.Query<Test>().FirstOrDefault(i => i.Id == test.Id);
                    if (!ReferenceEquals(expectedTest, null))
                    {
                        _session.Delete(expectedTest);
                        transaction.Commit();
                    }
                }
        }

        public void Update(Test test)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    Test entity = _session.Query<Test>().FirstOrDefault(i => i.Id == test.Id);
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
                    Test test = _session.Query<Test>().FirstOrDefault(i => i.Id == key);
                    if (!ReferenceEquals(test, null))
                    {
                        _session.Delete(test);
                        transaction.Commit();
                    }
                }
        }
    }
}
