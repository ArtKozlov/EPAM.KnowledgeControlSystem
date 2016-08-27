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
    }
}
