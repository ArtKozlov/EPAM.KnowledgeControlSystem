using System;
using ORM.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        IRoleRepository Roles { get; }

        IRepository<Test> Tests { get; }

        IRepository<TestResult> TestResults { get; }

        IRepository<Question> Questions { get; }

        IRepository<Answer> Answers { get; }
        void Save();
    }
}
