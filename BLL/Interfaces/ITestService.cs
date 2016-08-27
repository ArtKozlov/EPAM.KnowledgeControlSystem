
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ITestService
    {
        TestDTO GetTest(int id);

        IEnumerable<TestDTO> GetAllTests();
        void CreateTest(TestDTO test);
        void DeleteTest(TestDTO test);
        void DeleteTest(int id);
        void UpdateTest(TestDTO test);
    }
}
