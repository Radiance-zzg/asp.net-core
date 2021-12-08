using Autofac;
using Blog.Core.Repository;
using Blog.Core.Repository.UnitOfWork;
using Blog.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace MyBlogCore.AutofacConfig
{
    public class ConfigureAutofac : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().PropertiesAutowired();
            builder.RegisterAssemblyTypes(GetAssemblyByName("Blog.Core.Repository"))
                   .Where(a => a.Name.EndsWith("Repository"))
                   .AsSelf().AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(GetAssemblyByName("Blog.Core.Services"))
                .Where(a => a.Name.EndsWith("Service"))
                .AsSelf().AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();
            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
                .PropertiesAutowired();
        }
        /// <summary>
        /// 根据程序集名称获取程序集
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        public static System.Reflection.Assembly GetAssemblyByName(string assemblyName)
        {
            return Assembly.Load(assemblyName);
        }
    }
}
