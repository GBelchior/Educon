using Educon.Core;
using Educon.Data;
using Educon.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Educon
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterDependencies();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EduconContext, Data.Migrations.Configuration>());
        }

        private void RegisterDependencies()
        {
            Core.DependencyResolver.Register<IMultiplayerRepository, MultiplayerRepository>();
            Core.DependencyResolver.Register<IQuestionRepository, QuestionRepository>();
            Core.DependencyResolver.Register<IUserRepository, UserRepository>();
        }
    }
}
