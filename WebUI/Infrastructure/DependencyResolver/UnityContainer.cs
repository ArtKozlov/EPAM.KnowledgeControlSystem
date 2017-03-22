using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfaces;
using BLL.Registrars;
using BLL.Services;
using Microsoft.Practices.Unity;
using WebUI.Infrastructure.Providers;

namespace WebUI.Infrastructure.DependencyResolver
{
    public class UnityContainer
    {
        public static IUnityContainer BuildUnityContainer()
        {
            Microsoft.Practices.Unity.UnityContainer container = new Microsoft.Practices.Unity.UnityContainer();

            container.RegisterType<ITestService, TestService>(new PerResolveLifetimeManager());
            container.RegisterType<IUserService, UserService>(new PerResolveLifetimeManager());
            container.RegisterType<IRoleService, RoleService>(new PerResolveLifetimeManager());
            container.RegisterType<ITestResultService, TestResultService>(new PerResolveLifetimeManager());
            container.RegisterType<IAnswerService, AnswerService>(new PerResolveLifetimeManager());
            container.RegisterType<IQuestionService, QuestionService>(new PerResolveLifetimeManager());
            container.RegisterType<CustomMembershipProvider, CustomMembershipProvider>(new PerResolveLifetimeManager());
            container.RegisterType<CustomRoleProvider, CustomRoleProvider>(new PerResolveLifetimeManager());

            UnityBllConfig.BuildUnityBllContainer(container);

            return container;
        }
    }
}