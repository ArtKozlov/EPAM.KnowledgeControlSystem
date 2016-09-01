
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ITestResultService
    {
        TestResultDTO GetTestResult(int id);
        void CreateTestResult(TestResultDTO test);
        void DeleteTestResult(TestResultDTO test);
        void DeleteTestResult(int id);

        IEnumerable<TestResultDTO> GetAllTestResults();
    }
}
