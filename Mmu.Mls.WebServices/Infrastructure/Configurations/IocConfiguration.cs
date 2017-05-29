using System;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mls.WebServices.DataAccess.DocumentDb.Handlers;
using Mmu.Mls.WebServices.DataAccess.DocumentDb.Handlers.Implementation;
using Mmu.Mls.WebServices.DataAccess.Repositories;
using Mmu.Mls.WebServices.Infrastructure.Settings;
using Mmu.Mls.WebServices.Infrastructure.Settings.Implementation;
using StructureMap;

namespace Mmu.Mls.WebServices.Infrastructure.Configurations
{
    public static class IocConfiguration
    {
        internal static IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(
                config =>
                    {
                        config.Scan(
                            _ =>
                                {
                                    _.AssembliesFromApplicationBaseDirectory();
                                    _.WithDefaultConventions();
                                    _.AddAllTypesOf(typeof(IRepository<>));
                                });

                        config.For<IAppSettingsService>().Use<
                            AppSettingsService>().Singleton();
                        config.For<IDocumentClientSingleton>().Use<DocumentClientSingleton>().Singleton();

                        config.Populate(services);
                    });

            var result = container.GetInstance<IServiceProvider>();

            //ServiceProviderSingleton.SetServiceProvider(result);
            return result;
        }
    }
}