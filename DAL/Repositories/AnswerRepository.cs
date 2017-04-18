using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Entities;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ISession _session;

        public AnswerRepository(ISession session)
        {
            _session = session;
        }
        public IEnumerable<Answer> GetAll()
        {
                IEnumerable<Answer> result = _session.Query<Answer>().ToList();
                return result;
        }

        public Answer GetById(int key)
        {
                Answer answer = _session.Query<Answer>().FirstOrDefault(i => i.Id == key);
                return answer;
        }

        public void Create(Answer answer)
        {
            if (ReferenceEquals(answer, null))
                throw new ArgumentNullException();
            
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(answer);
                    transaction.Commit();
                }
        }

        public void Delete(Answer answer)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    Answer expectedAnswer = _session.Query<Answer>().FirstOrDefault(i => i.Id == answer.Id);
                    if (!ReferenceEquals(expectedAnswer, null))
                    {
                        _session.Delete(expectedAnswer);
                        transaction.Commit();
                    }
                }
        }

        public void Update(Answer answer)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    Answer entity = _session.Query<Answer>().FirstOrDefault(i => i.Id == answer.Id);
                    if (!ReferenceEquals(answer, null))
                    {
                        answer.Test = entity.Test;
                        _session.Evict(entity);
                        _session.Update(answer);
                        transaction.Commit();
                    }
                }
        }

        public void Delete(int key)
        {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    Answer answer = _session.Query<Answer>().FirstOrDefault(i => i.Id == key);
                    if (!ReferenceEquals(answer, null))
                    {
                        _session.Delete(answer);
                        transaction.Commit();
                    }
                }
        }
    }
}
