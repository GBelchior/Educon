using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Reflection;
using Educon.Data.Interfaces;

namespace Educon.Core
{
    public static class DependencyResolver
    {
        private static IUnityContainer FContainer;

        static DependencyResolver()
        {
            FContainer = new UnityContainer();
        }

        public static void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            FContainer.RegisterType<TInterface, TImplementation>();
        }

        public static T Resolve<T>()
        {
            if (!FContainer.IsRegistered<T>()) return default(T);

            return FContainer.Resolve<T>();
        }
    }
}
