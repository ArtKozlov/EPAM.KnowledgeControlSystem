using BLL.Interfaces;
using BLL.Registrars;
using BLL.Services;
using Microsoft.Practices.Unity;

namespace WebUI.Infrastructure.DependencyResolver
{
    public class UnityContainer
    {
        public static IUnityContainer BuildUnityContainer()
        {
            Microsoft.Practices.Unity.UnityContainer container = new Microsoft.Practices.Unity.UnityContainer();

            container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<ITestResultService, TestResultService>();
            container.RegisterType<IAnswerService, AnswerService>();
            container.RegisterType<IQuestionService, QuestionService>();

            UnityBllConfig.BuildUnityBllContainer(container);

            return container;
        }
    }
}