using RepositorioGitHub.Business;
using RepositorioGitHub.Business.Contract;
using RepositorioGitHub.Dominio.Interfaces;
using RepositorioGitHub.Infra.ApiGitHub;
using RepositorioGitHub.Infra.Contract;
using RepositorioGitHub.Infra.Repositorio;
using RepositoriosGitHub.Infra.CrossCutting.Adapter.Interfaces;
using RepositoriosGitHub.Infra.CrossCutting.Adapter.Map;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace RepositorioGitHub.App
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {


        }

        public static void RegistraComponentes()
        {
            var container = new UnityContainer();
            container.RegisterType<IGitHubApi, GitHubApi>();
            container.RegisterType<IContextRepository, ContextRepository>();
            container.RegisterType<IGitHubApiBusiness, GitHubApiBusiness>();
            container.RegisterType<IMapperGitHubRepository, MapperGitHubRepository>();
            container.RegisterType<IMapperRepository, MapperRepository>();
            container.RegisterType<IMapperFavorite, MapperFavorite>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}