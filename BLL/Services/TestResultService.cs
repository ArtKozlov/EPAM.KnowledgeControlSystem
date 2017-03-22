using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Mapping;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TestResultService : ITestResultService
    {
        private readonly IUnitOfWork _uow;

        public TestResultService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void CreateTestResult(TestResultDTO test)
        {
            _uow.TestResults.Create(test.ToTestResultEntity());
        }

        public void DeleteTestResult(int id)
        {
            _uow.TestResults.Delete(id);
        }

        public void DeleteTestResult(TestResultDTO test)
        {
            _uow.TestResults.Delete(test.ToTestResultEntity());
        }

        public IEnumerable<TestResultDTO> GetAllTestResults()
        {
            return _uow.TestResults.GetAll().Select(test => test.ToTestResultDto());
        }

        public TestResultDTO GetTestResult(int id)
        {
            var testResult = _uow.TestResults.GetById(id);
            if (ReferenceEquals(testResult, null))
                return null;
            return testResult.ToTestResultDto();
        }
    }
}
