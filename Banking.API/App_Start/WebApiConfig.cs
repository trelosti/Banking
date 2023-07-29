using Banking.API.App_Start;
using Banking.BLL.Interface;
using Banking.BLL.Service;
using Banking.DAL.Interface;
using Banking.DAL.Repository;
using Banking.Domain.Entity;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;

namespace Banking.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IBaseRepository<User>, UserRepository>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IAuthService, AuthService>();
            config.DependencyResolver = new UnityResolver(container);

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
