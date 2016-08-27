using System;
using DAL.Interfaces;
using DAL.Repositories;
using ORM;
using ORM.Entities;

namespace DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly TestingSystemContext _context;
        private UserRepository _userRepository;
        private RoleRepository _roleRepository;
        private TestRepository _testRepository;
        private TestResultRepository _testResultRepository;
        private QuestionRepository _questionRepository;
        private AnswerRepository _answerRepository;

        public UnitOfWork(TestingSystemContext context)
        {
            _context = context;
        }

#region binding with repositories
        public IUserRepository Users
        {
            get
            {
                if (ReferenceEquals(_userRepository,null))
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                if (ReferenceEquals(_roleRepository, null))
                    _roleRepository = new RoleRepository(_context);
                return _roleRepository;
            }
        }

        public IRepository<Test> Tests
        {
            get
            {
                if (ReferenceEquals(_testRepository, null))
                    _testRepository = new TestRepository(_context);
                return _testRepository;
            }
        }

        public IRepository<TestResult> TestResults
        {
            get
            {
                if (ReferenceEquals(_testResultRepository, null))
                    _testResultRepository = new TestResultRepository(_context);
                return _testResultRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (ReferenceEquals(_questionRepository, null))
                    _questionRepository = new QuestionRepository(_context);
                return _questionRepository;
            }
        }

        public IRepository<Answer> Answers
        {
            get
            {
                if (ReferenceEquals(_answerRepository, null))
                    _answerRepository = new AnswerRepository(_context);
                return _answerRepository;
            }
        }
#endregion 

        public void Save()
        {
            if (!ReferenceEquals(_context,null))
            {
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            if (!ReferenceEquals(_context, null))
            {
                _context.Dispose();
            }
        }
    }
}
