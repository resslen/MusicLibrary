﻿using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace MusicLibrary.App_Start
{
    public static class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            Register(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void Register(ContainerBuilder builder)
        {
            
        }
    }
}