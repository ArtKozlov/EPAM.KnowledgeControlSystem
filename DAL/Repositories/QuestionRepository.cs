using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Entities;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ISession _session;

        public QuestionRepository(ISession session)
        {
            _session = session;
        }

        public IEnumerable<Question> GetAll()
        {
                IEnumerable<Question> result = _session.Query<Question>().ToList();
                return result;
        }

        public Question GetById(int key)
        {
                Question question = _session.Query<Question>().FirstOrDefault(i => i.Id == key);
                return question;
        }

        public void Create(Question question)
        {
            if (ReferenceEquals(question, null))
                throw new ArgumentNullException();
            
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(question);
                    transaction.Commit();
                }
        }

        public void Delete(Question question)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    Question expectedQuestion = _session.Query<Question>().FirstOrDefault(i => i.Id == question.Id);
                    if (!ReferenceEquals(expectedQuestion, null))
                    {
                        _session.Delete(expectedQuestion);
                        transaction.Commit();
                    }
                }
        }

        public void Update(Question question)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    Question entity = _session.Query<Question>().FirstOrDefault(i => i.Id == question.Id);
                    if (!ReferenceEquals(question, null))
                    {
                        question.Test = entity.Test;
                        _session.Evict(entity);
                        _session.Update(question);
                        transaction.Commit();
                    }
                }
        }

        public void Delete(int key)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    Question question = _session.Query<Question>().FirstOrDefault(i => i.Id == key);
                    if (!ReferenceEquals(question, null))
                    {
                        _session.Delete(question);
                        transaction.Commit();
                    }
                }
        }
    }
}
