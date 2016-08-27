using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }

        static void Main(string[] args)
        {
            var service = resolver.Get<IUserService>();
            var service2 = resolver.Get<IRoleService>();
           // var obj3 = new UserDTO();
           //obj3.Name = "Gut";
           // service.CreateUser(obj3);

            var list = service.GetAllUsers().ToList();
           // var list2 = service2.GetAllRoles().ToList();
            foreach (var user in list)
            {
                Console.WriteLine(user.Name);
            }
            Console.WriteLine("END");
            Console.ReadKey();
        }
    }
}
