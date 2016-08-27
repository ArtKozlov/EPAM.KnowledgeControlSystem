
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ITestResultService
    {
        TestResultDTO GetTestResult(int id);

        IEnumerable<TestResultDTO> GetAllTestResults();
    }
}
