using System.Web.Mvc;
using CricketInsighter.Bootstrapper;
using CricketInsighter.Core.Data;
using CricketInsighter.Core.Logging;
using CricketInsighter.Core.Services;
using CricketInsighter.Data;
using CricketInsighter.Infrastructure.Logging;
using CricketInsighter.Services;
using CricketInsighter.Web;
using Autofac;
using Autofac.Integration.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IocConfig), "RegisterDependencies")]

namespace CricketInsighter.Bootstrapper
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            const string nameOrConnectionString = "name=AppContext";
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerRequest();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
            builder.Register<IEntitiesContext>(b =>
            {
                var logger = b.Resolve<ILogger>();
                var context = new AspnetIdentityWithOnionContext(nameOrConnectionString, logger);
                return context;
            }).InstancePerRequest();
            builder.Register(b => NLogLogger.Instance).SingleInstance();
            builder.RegisterModule(new IdentityModule());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
