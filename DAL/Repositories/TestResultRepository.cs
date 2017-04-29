using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Entities;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Repositories
{
    public class TestResultRepository : ITestResultRepository
    {
        private readonly ISession _session;

        public TestResultRepository(ISession session)
        {
            _session = session;
        }

        public IEnumerable<TestResult> GetAll()
        {
                IEnumerable<TestResult> result = _session.Query<TestResult>().ToList();
                return result;
        }

        public TestResult GetById(int key)
        {
                TestResult testResult = _session.Query<TestResult>().FirstOrDefault(i => i.Id == key);
                return testResult;
        }

        public void Create(TestResult testResult)
        {
            if (ReferenceEquals(testResult, null))
                throw new ArgumentNullException();
            
                using (ITransaction transaction = _session.BeginTransaction())
                {

                    _session.Evict(testResult.User);
                    _session.Save(testResult);
                    transaction.Commit();
                }
        }

        public void Delete(TestResult testResult)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    TestResult expectedTestResult = _session.Query<TestResult>().FirstOrDefault(i => i.Id == testResult.Id);
                    if (!ReferenceEquals(expectedTestResult, null))
                    {
                        _session.Delete(expectedTestResult);
                        transaction.Commit();
                    }
                }
        }

        public void Update(TestResult testResult)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    TestResult entity = _session.Query<TestResult>().FirstOrDefault(i => i.Id == testResult.Id);
                    if (!ReferenceEquals(testResult, null))
                    {
                        testResult.User = entity.User;
                        _session.Evict(entity);
                        _session.Update(testResult);
                        transaction.Commit();
                    }
                }
        }

        public void Delete(int key)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    TestResult testResult = _session.Query<TestResult>().FirstOrDefault(i => i.Id == key);
                    if (!ReferenceEquals(testResult, null))
                    {
                        _session.Delete(testResult);
                        transaction.Commit();
                    }
                }
        }
    }
}
