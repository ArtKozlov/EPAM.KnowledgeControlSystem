using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;
using ORM;
using ORM.Entities;

namespace DAL.Repositories
{
    public class TestRepository: IRepository<Test>
    {
        private readonly TestingSystemContext _context;

        public TestRepository(TestingSystemContext uow)
        {
            _context = uow;
        }
        public IEnumerable<Test> GetAll()
        {
            return _context.Tests;
        }

        public Test GetById(int key)
        {
            return _context.Tests.Find(key);
        }

        public void Create(Test test)
        {
            _context.Tests.Add(test);
        }

        public void Delete(Test test)
        {
            var expectedTest = _context.Tests.Single(u => u.Id == test.Id);
            if (!ReferenceEquals(expectedTest, null))
                _context.Tests.Remove(expectedTest);
        }

        public void Update(Test test)
        {
            var entity = _context.Tests.Find(test.Id);
            entity.Name = test.Name;
            entity.GoodAnswers = test.GoodAnswers;
            entity.BadAnswers = test.BadAnswers;
            entity.Time = test.Time;
            entity.IsValid = test.IsValid;
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int key)
        {
            var expectedTest = _context.Tests.Find(key);
            if (!ReferenceEquals(expectedTest, null))
                _context.Tests.Remove(expectedTest);
        }
    }
}
