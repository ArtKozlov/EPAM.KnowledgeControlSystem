using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Practices.Unity;

namespace BLL.Registrars
{
    public class UnityBllConfig
    {
        public static void BuildUnityBllContainer(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager());
        }
    }
}
