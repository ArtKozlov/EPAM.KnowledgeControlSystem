using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;
using ORM;
using ORM.Entities;

namespace DAL.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private readonly TestingSystemContext _context;

        public QuestionRepository(TestingSystemContext uow)
        {
            _context = uow;
        }
        public IEnumerable<Question> GetAll()
        {
            return _context.Questions;
        }

        public Question GetById(int key)
        {
            return _context.Questions.Find(key);
        }

        public void Create(Question question)
        {
            _context.Questions.Add(question);
        }

        public void Delete(Question question)
        {
            var expectedQuestion = _context.Questions.Single(u => u.Id == question.Id);
            if (!ReferenceEquals(expectedQuestion, null))
                _context.Questions.Remove(expectedQuestion);
        }

        public void Update(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
        }

        public void Delete(int key)
        {
            var expectedQuestion = _context.Questions.Find(key);
            if (!ReferenceEquals(expectedQuestion, null))
                _context.Questions.Remove(expectedQuestion);
        }
    }
}
