using Ask2Friends.BLL.Interfaces;
using Ask2Friends.BLL.Managers;
using Ask2Friends.DAL.Concrete.EntityFramework;
using Ask2Friends.DAL.Interfaces;
using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Castle.DynamicProxy;
using MG.Core.Utilities.Interceptors;
using MG.Core.Utilities.Security.Common;
using MG.Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask2Friends.BLL.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDAL>().As<IUserDAL>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterModule(new AutoMapperModule());

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
