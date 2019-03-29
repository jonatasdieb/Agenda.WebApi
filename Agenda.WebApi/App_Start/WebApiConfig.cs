using Agenda.Data.Repositories;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Domain.Interfaces.Services;
using Agenda.Domain.Services;
using Agenda.WebApi.AutoMapper;
using Agenda.WebApi.Unity;
using AutoMapper;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;

namespace Agenda.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IRepositoryBase<Type>, RepositoryBase<Type>>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceBase<Type>, ServiceBase<Type>>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaRepository, PessoaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEnderecoRepository, EnderecoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEnderecoTipoRepository, EnderecoTipoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IContatoRepository, ContatoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IContatoTipoRepository, ContatoTipoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaMarcadorRepository, PessoaMarcadorRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaService, PessoaService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEnderecoService, EnderecoService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEnderecoTipoService, EnderecoTipoService>(new HierarchicalLifetimeManager());
            container.RegisterType<IContatoService, ContatoService>(new HierarchicalLifetimeManager());
            container.RegisterType<IContatoTipoService, ContatoTipoService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaMarcadorService, PessoaMarcadorService>(new HierarchicalLifetimeManager());
            container.RegisterInstance<IMapper>(AutoMapperConfig.RegisterMappings());
            config.DependencyResolver = new UnityResolver(container);

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
