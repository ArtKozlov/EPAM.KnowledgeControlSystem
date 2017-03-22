using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Mapping;
using DAL.Interfaces;

namespace BLL.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _uow;

        public AnswerService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void CreateAnswer(AnswerDTO answer)
        {
            _uow.Answers.Create(answer.ToAnswerEntity());
        }

        public void DeleteAnswer(int id)
        {
            _uow.Answers.Delete(id);
        }

        public void DeleteAnswer(AnswerDTO answer)
        {
            _uow.Answers.Delete(answer.ToAnswerEntity());
        }

        public IEnumerable<AnswerDTO> GetAllAnswers()
        {
            return _uow.Answers.GetAll().Select(answer => answer.ToAnswerDto());
        }

        public AnswerDTO GetAnswer(int id)
        {
            var answer = _uow.Answers.GetById(id);
            if (ReferenceEquals(answer, null))
                return null;
            return answer.ToAnswerDto();
        }
        public void UpdateAnswer(AnswerDTO answer)
        {
            _uow.Answers.Update(answer.ToAnswerEntity());
        }
    }
}
