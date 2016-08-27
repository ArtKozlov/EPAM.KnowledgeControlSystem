using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;
using ORM;
using ORM.Entities;

namespace DAL.Repositories
{
    public class AnswerRepository : IRepository<Answer>
    {
        private readonly TestingSystemContext _context;

        public AnswerRepository(TestingSystemContext uow)
        {
            _context = uow;
        }
        public IEnumerable<Answer> GetAll()
        {
            return _context.Answers;
        }

        public Answer GetById(int key)
        {
            return _context.Answers.Find(key);
        }

        public void Create(Answer answer)
        {
            _context.Answers.Add(answer);
        }

        public void Delete(Answer answer)
        {
            var expectedAnswer = _context.Answers.Single(u => u.Id == answer.Id);
            if (!ReferenceEquals(expectedAnswer, null))
                _context.Answers.Remove(expectedAnswer);
        }

        public void Update(Answer answer)
        {
            _context.Entry(answer).State = EntityState.Modified;
        }

        public void Delete(int key)
        {
            var expectedAnswer = _context.Answers.Find(key);
            if (!ReferenceEquals(expectedAnswer, null))
                _context.Answers.Remove(expectedAnswer);
        }
    }
}
