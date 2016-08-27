using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;
using ORM;
using ORM.Entities;

namespace DAL.Repositories
{
    public class TestResultRepository : IRepository<TestResult>
    {
        private readonly TestingSystemContext _context;

        public TestResultRepository(TestingSystemContext uow)
        {
            _context = uow;
        }
        public IEnumerable<TestResult> GetAll()
        {
            return _context.TestResults;
        }

        public TestResult GetById(int key)
        {
            return _context.TestResults.Find(key);
        }

        public void Create(TestResult testResult)
        {
            _context.TestResults.Add(testResult);
        }

        public void Delete(TestResult testResult)
        {
            var expectedTestResult = _context.TestResults.Single(u => u.Id == testResult.Id);
            if (!ReferenceEquals(expectedTestResult, null))
                _context.TestResults.Remove(expectedTestResult);
        }

        public void Update(TestResult testResult)
        {
            _context.Entry(testResult).State = EntityState.Modified;
        }

        public void Delete(int key)
        {
            var expectedTestResult = _context.TestResults.Find(key);
            if (!ReferenceEquals(expectedTestResult, null))
                _context.TestResults.Remove(expectedTestResult);
        }
    }
}
