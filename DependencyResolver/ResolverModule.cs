using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void Configure(this IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<ITestService>().To<TestService>();
            kernel.Bind<ITestResultService>().To<TestResultService>();
            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<IAnswerService>().To<AnswerService>();

        }
    }
}