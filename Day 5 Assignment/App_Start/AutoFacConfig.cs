using Autofac;
using Autofac.Integration.Mvc;
using DataAccessLayer;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day_5_Assignment.App_Start
{
    public static class AutoFacConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<UniteOfWork>().As<IUniteOfWork>().InstancePerRequest();
            builder.RegisterGeneric(typeof(MainRepo<>)).As(typeof(IMainRepo<>)).InstancePerRequest();
            builder.RegisterType<ContextFactory>().As<IContextFactory>().InstancePerRequest();

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}