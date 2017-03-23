using DAL.Interfaces;
using DAL.Entities;
using DAL.NHibernate;
using NHibernate;

namespace DAL.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ISession _session = NHibernateHelper.OpenSession();

        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private ITestRepository _testRepository;
        private ITestResultRepository _testResultRepository;
        private IQuestionRepository _questionRepository;
        private IAnswerRepository _answerRepository;

#region binding with repositories
        public IUserRepository Users
        {
            get
            {
                if (ReferenceEquals(_userRepository,null))
                    _userRepository = new UserRepository(_session);
                return _userRepository;
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                if (ReferenceEquals(_roleRepository, null))
                    _roleRepository = new RoleRepository(_session);
                return _roleRepository;
            }
        }

        public IRepository<Test> Tests
        {
            get
            {
                if (ReferenceEquals(_testRepository, null))
                    _testRepository = new TestRepository(_session);
                return _testRepository;
            }
        }

        public IRepository<TestResult> TestResults
        {
            get
            {
                if (ReferenceEquals(_testResultRepository, null))
                    _testResultRepository = new TestResultRepository(_session);
                return _testResultRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (ReferenceEquals(_questionRepository, null))
                    _questionRepository = new QuestionRepository(_session);
                return _questionRepository;
            }
        }

        public IRepository<Answer> Answers
        {
            get
            {
                if (ReferenceEquals(_answerRepository, null))
                    _answerRepository = new AnswerRepository(_session);
                return _answerRepository;
            }
        }
        #endregion

        //public void Dispose()
        //{
        //    if (!ReferenceEquals(_session, null))
        //    {
        //        _session.Dispose();
        //    }
        //}
    }
}
