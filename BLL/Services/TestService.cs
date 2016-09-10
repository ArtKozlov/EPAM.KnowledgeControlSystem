using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Mapping;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _uow;

        public TestService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void CreateTest(TestDTO test)
        {
            _uow.Tests.Create(test.ToTestEntity());
            _uow.Save();
        }

        public void DeleteTest(int id)
        {
            _uow.Tests.Delete(id);
            _uow.Save();
        }

        public void DeleteTest(TestDTO test)
        {
            _uow.Tests.Delete(test.ToTestEntity());
            _uow.Save();
        }

        public IEnumerable<TestDTO> GetAllTests()
        {
            return _uow.Tests.GetAll().Select(test => test.ToTestDto());
        }

        public TestDTO GetTest(int id)
        {
            var test = _uow.Tests.GetById(id);
            if (ReferenceEquals(test, null))
                return null;
            return test.ToTestDto();
        }

        public void UpdateTest(TestDTO test)
        {
            _uow.Tests.Update(test.ToTestEntity());
            _uow.Save();
        }

        public TestResultDTO CheckAnswers(TestDTO test)
        {
            var entityModel = _uow.Tests.GetById(test.Id).ToTestDto();
            List<AnswerDTO> lhs = entityModel.Answers.ToList();
            List<string> rhs = new List<string>();
            foreach (var answer in test.Answers)
            {
                if (!ReferenceEquals(answer.Value, null))
                    rhs.Add(answer.Value);
                else
                {
                    rhs.Add(String.Empty);
                }
            }
            foreach (var answer in entityModel.Answers)
            {
                if (ReferenceEquals(answer.Value, null))
                    answer.Value = String.Empty;
            }
            int goodAnswers = 0;
            for (int i = 0; i < test.Answers.Count; i++)
            {
                if (lhs[i].Value.ToLower() == rhs[i].ToLower())
                    goodAnswers++;
            }
            int badAnswers = test.Answers.Count - goodAnswers;
            return new TestResultDTO()
            {
                GoodAnswers = goodAnswers,
                BadAnswers = badAnswers
            };
        }
    }
}
